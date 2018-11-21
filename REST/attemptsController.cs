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

namespace REST
{
    public class attemptsController : ApiController
    {
        private WebAdminEntities db = new WebAdminEntities();

        // GET: api/attempts
        public IQueryable<attempt> Getattempts()
        {
            return db.attempts;
        }

        // GET: api/attempts/5
        [ResponseType(typeof(attempt))]
        public IHttpActionResult Getattempt(int id)
        {
            attempt attempt = db.attempts.Find(id);
            if (attempt == null)
            {
                return NotFound();
            }

            return Ok(attempt);
        }

        // PUT: api/attempts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putattempt(int id, attempt attempt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attempt.attemptID)
            {
                return BadRequest();
            }

            db.Entry(attempt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!attemptExists(id))
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

        // POST: api/attempts
        [ResponseType(typeof(attempt))]
        public IHttpActionResult Postattempt(attempt attempt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.attempts.Add(attempt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = attempt.attemptID }, attempt);
        }

        // DELETE: api/attempts/5
        [ResponseType(typeof(attempt))]
        public IHttpActionResult Deleteattempt(int id)
        {
            attempt attempt = db.attempts.Find(id);
            if (attempt == null)
            {
                return NotFound();
            }

            db.attempts.Remove(attempt);
            db.SaveChanges();

            return Ok(attempt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool attemptExists(int id)
        {
            return db.attempts.Count(e => e.attemptID == id) > 0;
        }
    }
}