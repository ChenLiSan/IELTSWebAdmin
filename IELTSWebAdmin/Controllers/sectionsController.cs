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
    public class sectionsController : ApiController
    {
        private WebAdminEntities db = new WebAdminEntities();

        // GET: api/sections
        public IQueryable<section> Getsections()
        {
            return db.sections;
        }

        // GET: api/sections/5
        [ResponseType(typeof(section))]
        public IHttpActionResult Getsection(int id)
        {
            section section = db.sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }

            return Ok(section);
        }

        // PUT: api/sections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsection(int id, section section)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != section.sectionID)
            {
                return BadRequest();
            }

            db.Entry(section).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sectionExists(id))
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

        // POST: api/sections
        [ResponseType(typeof(section))]
        public IHttpActionResult Postsection(section section)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sections.Add(section);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = section.sectionID }, section);
        }

        // DELETE: api/sections/5
        [ResponseType(typeof(section))]
        public IHttpActionResult Deletesection(int id)
        {
            section section = db.sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }

            db.sections.Remove(section);
            db.SaveChanges();

            return Ok(section);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sectionExists(int id)
        {
            return db.sections.Count(e => e.sectionID == id) > 0;
        }
    }
}