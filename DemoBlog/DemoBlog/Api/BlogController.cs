using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using DemoBlog.Models;
using Raven.Client;

namespace DemoBlog.Api
{
    public class BlogController : RavenApiController
    {
        // GET api/blog
        public async Task<IEnumerable<Entry>> Get()
        {
            return await Session.Query<Entry>().ToListAsync();
        }

        // GET api/blog/5
        public async Task<Entry> Get(string slug)
        {
            return await Session.LoadAsync<Entry>(slug);
        }

        // POST api/blog
        public Task Post([FromBody]Entry value)
        {
            return Session.StoreAsync(value);
        }

        // PUT api/blog/5
        public async Task Put(string slug, [FromBody]Entry value)
        {
            var entry = await Session.LoadAsync<Entry>(slug);
            entry.Title = value.Title;
            entry.Content = value.Content;
            entry.Tags = value.Tags;
        }

        // DELETE api/blog/5
        public void Delete(string slug)
        {
        }
    }
}
