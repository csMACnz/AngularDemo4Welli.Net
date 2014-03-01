using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using DemoBlog.Application;
using Raven.Client;
using Raven.Client.Embedded;

namespace DemoBlog.Api
{
    public abstract class RavenApiController : ApiController
    {
        
        public IAsyncDocumentSession Session { get; set; }

        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            using (Session = Repository.OpenAsyncSession())
            {
                var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                await Session.SaveChangesAsync();

                return result;
            }
        }
    }
}