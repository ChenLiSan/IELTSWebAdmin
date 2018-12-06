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
using IELTSWebAdmin;

namespace IELTSWebAdmin.Controllers
{
    public class sessionsController : ApiController
    {
        private WebAdminEntities db = new WebAdminEntities();

        // GET: api/sessions
        public IQueryable<session> Getsessions()
        {
            return db.sessions;
        }

        // GET: api/sessions/5
        [ResponseType(typeof(session))]
        public IHttpActionResult Getsession(int id)
        {
            session session = db.sessions.Find(id);
            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        // PUT: api/sessions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsession(int id, session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != session.sessionID)
            {
                return BadRequest();
            }

            db.Entry(session).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sessionExists(id))
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

        // POST: api/sessions
        [ResponseType(typeof(session))]
        public IHttpActionResult Postsession(session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sessions.Add(session);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = session.sessionID }, session);
        }

        // DELETE: api/sessions/5
        [ResponseType(typeof(session))]
        public IHttpActionResult Deletesession(int id)
        {
            session session = db.sessions.Find(id);
            if (session == null)
            {
                return NotFound();
            }

            db.sessions.Remove(session);
            db.SaveChanges();

            return Ok(session);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sessionExists(int id)
        {
            return db.sessions.Count(e => e.sessionID == id) > 0;
        }
    }
}