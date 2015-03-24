using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Models;

namespace Api.Controllers
{
    //Enable cross domain request
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BlobsController : ApiController
    {
        private AzureContext db = new AzureContext();

        // GET: api/Blobs
        public IQueryable<Blob> GetBlobs()
        {
            return db.Blobs;
        }

        // GET: api/Blobs/5
        [ResponseType(typeof(Blob))]
        public IHttpActionResult GetBlob(int id)
        {
            Blob blob = db.Blobs.Find(id);
            if (blob == null)
            {
                return NotFound();
            }

            return Ok(blob);
        }

        // PUT: api/Blobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlob(int id, Blob blob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blob.Id)
            {
                return BadRequest();
            }

            //db.Entry(blob).State = EntityState.Modified;

            var foundEntity = db.Blobs.FirstOrDefault(t => t.Id == id);
            if (foundEntity != null)
            {
                foundEntity.LastUpdatedBy = "fareast\v-hary";
                foundEntity.LastUpdatedDate = DateTime.UtcNow;

                foundEntity.BlobName = blob.BlobName;
                foundEntity.BlobUrl = blob.BlobUrl;
                foundEntity.Description = blob.Description;

                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Blobs
        [ResponseType(typeof(Blob))]
        public IHttpActionResult PostBlob(Blob blob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            blob.UploadedBy = "fareast\v-hary";
            blob.LastUpdatedBy = blob.UploadedBy;
            blob.UploadedDate = DateTime.UtcNow;
            blob.LastUpdatedDate = blob.UploadedDate;

            db.Blobs.Add(blob);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = blob.Id }, blob);
        }

        // DELETE: api/Blobs/5
        [ResponseType(typeof(Blob))]
        public IHttpActionResult DeleteBlob(int id)
        {
            Blob blob = db.Blobs.Find(id);
            if (blob == null)
            {
                return NotFound();
            }

            db.Blobs.Remove(blob);
            db.SaveChanges();

            return Ok(blob);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlobExists(int id)
        {
            return db.Blobs.Count(e => e.Id == id) > 0;
        }
    }
}