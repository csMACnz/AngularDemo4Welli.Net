using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace DemoBlog.Application
{
    public static class Repository
    {
        public static IDocumentStore Store
        {
            get { return LazyStore.Value; }
        }

        private static readonly Lazy<IDocumentStore> LazyStore = new Lazy<IDocumentStore>(() =>
        {
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
            var store = new EmbeddableDocumentStore()
            {
                //UseEmbeddedHttpServer = true,
            };

            store.Initialize();

            return store;
        });

        public static IAsyncDocumentSession OpenAsyncSession()
        {
            return Store.OpenAsyncSession();
        }

        public static IDocumentSession OpenSession()
        {
            return Store.OpenSession(); 
        }
    }
}