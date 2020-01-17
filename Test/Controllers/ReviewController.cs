using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.ViewModels;
using Test.Models;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Data.Entity;

namespace Test.Controllers
{
    public class ReviewController : ApiController
    {
        // GET: api/Review
        [ResponseType(typeof(List<ReviewItem>))]
        public async Task<IHttpActionResult> Get()
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                List<ReviewItem> list = await db.Reviews.Select(q => new ReviewItem()
                {
                    ID = q.ID,
                    ClientName = q.ClientName,
                    Review = q.Review
                }).ToListAsync();
                return Ok(list);
            }
        }

        // GET: api/Review/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Review
        [ResponseType(typeof(ReviewItem))]
        public async Task<IHttpActionResult> Post(ReviewItem item)
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                Reviews rec = new Reviews()
                {
                    ClientName = item.ClientName,
                    Review = item.Review
                };
                db.Reviews.Add(rec);
                await db.SaveChangesAsync();
                item.ID = rec.ID;
                return Ok(item);
            }
        }

        // PUT: api/Review/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Review/5
        //public void Delete(int id)
        //{
        //}
    }
}
