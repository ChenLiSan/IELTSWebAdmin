using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace REST2
{
    public class papersController : ApiController
    {
        private WebAdminEntities db = new WebAdminEntities();

        // GET: api/papers
        public IQueryable<paper> Getpapers()
        {
            return db.papers;
        }

        // GET: api/papers/5
        [ResponseType(typeof(paper))]
        public IHttpActionResult Getpaper(int id)
        {
            paper paper = db.papers.Find(id);
            if (paper == null)
            {
                return NotFound();
            }

            return Ok(paper);
        }

        // PUT: api/papers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpaper(int id, paper paper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paper.paperID)
            {
                return BadRequest();
            }

            db.Entry(paper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paperExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/papers
        [ResponseType(typeof(paper))]
        public IHttpActionResult Postpaper(paper paper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.papers.Add(paper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paper.paperID }, paper);
        }

        // DELETE: api/papers/5
        [ResponseType(typeof(paper))]
        public IHttpActionResult Deletepaper(int id)
        {
            paper paper = db.papers.Find(id);
            if (paper == null)
            {
                return NotFound();
            }

            db.papers.Remove(paper);
            db.SaveChanges();

            return Ok(paper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool paperExists(int id)
        {
            return db.papers.Count(e => e.paperID == id) > 0;
        }
    }
}