using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DemoBlog.Application;
using DemoBlog.Models;
using Raven.Client;
using Raven.Client.Linq;

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
            return await Session.Query<Entry>().Where(e=>e.Slug==slug).FirstOrDefaultAsync();
        }

        // POST api/blog
        public async Task<HttpResponseMessage> Post([FromBody]Entry value)
        {
            var newslug = Repository.CreateSlug(value.Title);
            if (await Session.Query<Entry>().AnyAsync(e => e.Slug == newslug))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            value.Slug = newslug;
            value.CreationDate = DateTime.Now;
            value.PublishDate = DateTime.Now;
            value.Author = "csmacnz";
            await Session.StoreAsync(value);
            var newItem = await Session.LoadAsync<Entry>(value.Id);

            var response = Request.CreateResponse(HttpStatusCode.Created, newItem);

            string uri = Url.Link("BlogApi", new { slug = newItem.Slug });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        // PUT api/blog/5
        public async Task<HttpResponseMessage> Put(string slug, [FromBody]Entry value)
        {
            var entry = await Get(slug);
            if (entry == null) return new HttpResponseMessage(HttpStatusCode.NotFound);

            entry.CreationDate = entry.CreationDate > DateTime.MinValue ? entry.CreationDate : DateTime.Now;
            entry.PublishDate = entry.PublishDate ?? DateTime.Now;
            entry.Author = entry.Author ?? "csmacnz";
            entry.Title = value.Title;
            entry.Content = value.Content;

            return new HttpResponseMessage();
        }

        // DELETE api/blog/5
        public void Delete(string slug)
        {
        }
    }
}
