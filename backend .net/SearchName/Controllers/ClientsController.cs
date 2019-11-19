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
using System.Web.Routing;

namespace SearchName.Controllers
{
    public class ClientsController : ApiController
    {
        private SearchNameContext db = new SearchNameContext();

        // GET: api/Clients
        [Route("search/")]
        public IQueryable<Client> GetClients()
        {
            return db.Clients.Include(s => s.clientObj);
        }

       
        [Route("search/{fname}")]
        public IHttpActionResult GetClientByFirstName(string fname)
        {
            IList<Client> clients = null;
            clients = db.Clients.Include(ca => ca.clientObj).Where(fn => fn.FirstName.Contains(fname) || (fn.LastName.Contains(fname))).ToList();
            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }
          [Route("search/{firstName}/{lastName}")]
        public IHttpActionResult GetClientByBothName(string firstName, string lastName)
        {
            var clients = db.Clients.Include(ca => ca.clientObj).Where(n => n.FirstName == firstName && n.LastName == lastName).ToList();

            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        } 
        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.id }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.id == id) > 0;
        }
    }
}