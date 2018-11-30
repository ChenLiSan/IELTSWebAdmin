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
    public class staffsController : ApiController
    {
        private WebAdminEntities db = new WebAdminEntities();

        // GET: api/staffs
        public IQueryable<staff> Getstaffs()
        {
            return db.staffs;
        }

        // GET: api/staffs/5
        [ResponseType(typeof(staff))]
        public IHttpActionResult Getstaff(int id)
        {
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // PUT: api/staffs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putstaff(int id, staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff.staffID)
            {
                return BadRequest();
            }

            db.Entry(staff).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!staffExists(id))
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

        // POST: api/staffs
        [ResponseType(typeof(staff))]
        public IHttpActionResult Poststaff(staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.staffs.Add(staff);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = staff.staffID }, staff);
        }

        // DELETE: api/staffs/5
        [ResponseType(typeof(staff))]
        public IHttpActionResult Deletestaff(int id)
        {
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return NotFound();
            }

            db.staffs.Remove(staff);
            db.SaveChanges();

            return Ok(staff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool staffExists(int id)
        {
            return db.staffs.Count(e => e.staffID == id) > 0;
        }
    }
}