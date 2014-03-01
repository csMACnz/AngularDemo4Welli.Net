using System.Web.Mvc;
using DemoBlog.Application;
using Raven.Client;

namespace DemoBlog.Controllers
{
    public abstract class RavenController : Controller
    {  
        public new IDocumentSession Session { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session = Repository.OpenSession();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            using (Session)
            {
                if (filterContext.Exception != null)
                    return;

                if (Session != null)
                    Session.SaveChanges();
            }
        }
    }
}