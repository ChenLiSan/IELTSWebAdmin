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
    public class subsectionsController : ApiController
    {
        private WebAdminEntities db = new WebAdminEntities();

        // GET: api/subsections
        public IQueryable<subsection> Getsubsections()
        {
            return db.subsections;
        }

        // GET: api/subsections/5
        [ResponseType(typeof(subsection))]
        public IHttpActionResult Getsubsection(int id)
        {
            subsection subsection = db.subsections.Find(id);
            if (subsection == null)
            {
                return NotFound();
            }

            return Ok(subsection);
        }

        // PUT: api/subsections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsubsection(int id, subsection subsection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subsection.subsectionID)
            {
                return BadRequest();
            }

            db.Entry(subsection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subsectionExists(id))
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

        // POST: api/subsections
        [ResponseType(typeof(subsection))]
        public IHttpActionResult Postsubsection(subsection subsection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.subsections.Add(subsection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subsection.subsectionID }, subsection);
        }

        // DELETE: api/subsections/5
        [ResponseType(typeof(subsection))]
        public IHttpActionResult Deletesubsection(int id)
        {
            subsection subsection = db.subsections.Find(id);
            if (subsection == null)
            {
                return NotFound();
            }

            db.subsections.Remove(subsection);
            db.SaveChanges();

            return Ok(subsection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subsectionExists(int id)
        {
            return db.subsections.Count(e => e.subsectionID == id) > 0;
        }
    }
}