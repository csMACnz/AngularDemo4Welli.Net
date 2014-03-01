using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Raven.Client;
using Raven.Client.Embedded;

namespace DemoBlog.Api
{
    public abstract class RavenApiController : ApiController
    {
        public IDocumentStore Store
        {
            get { return LazyStore.Value; }
        }

        private static readonly Lazy<IDocumentStore> LazyStore = new Lazy<IDocumentStore>(() =>
        {
            var store = new EmbeddableDocumentStore();
            
            store.Initialize();

            return store;
        });
   
        public IAsyncDocumentSession Session { get; set; }

        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            using (Session = Store.OpenAsyncSession())
            {
                var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                await Session.SaveChangesAsync();

                return result;
            }
        }
    }
}