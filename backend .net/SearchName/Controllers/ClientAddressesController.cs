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
using SearchName.Models;

namespace SearchName.Controllers
{
    public class ClientAddressesController : ApiController
    {
        private SearchNameContext db = new SearchNameContext();

        // GET: api/ClientAddresses
        public IQueryable<ClientAddress> GetClientAddresses()
        {
            return db.ClientAddresses;
        }

        // GET: api/ClientAddresses/5
        [ResponseType(typeof(ClientAddress))]
        public IHttpActionResult GetClientAddress(int id)
        {
            ClientAddress clientAddress = db.ClientAddresses.Find(id);
            if (clientAddress == null)
            {
                return NotFound();
            }

            return Ok(clientAddress);
        }

        // PUT: api/ClientAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientAddress(int id, ClientAddress clientAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientAddress.id)
            {
                return BadRequest();
            }

            db.Entry(clientAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientAddressExists(id))
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

        // POST: api/ClientAddresses
        [ResponseType(typeof(ClientAddress))]
        public IHttpActionResult PostClientAddress(ClientAddress clientAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientAddresses.Add(clientAddress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clientAddress.id }, clientAddress);
        }

        // DELETE: api/ClientAddresses/5
        [ResponseType(typeof(ClientAddress))]
        public IHttpActionResult DeleteClientAddress(int id)
        {
            ClientAddress clientAddress = db.ClientAddresses.Find(id);
            if (clientAddress == null)
            {
                return NotFound();
            }

            db.ClientAddresses.Remove(clientAddress);
            db.SaveChanges();

            return Ok(clientAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientAddressExists(int id)
        {
            return db.ClientAddresses.Count(e => e.id == id) > 0;
        }
    }
}