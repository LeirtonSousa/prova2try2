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
using ProvaP2API.Connect;
using ProvaP2API.Models;

namespace ProvaP2API.Controllers
{
    public class AlugueisController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Alugueis
        public IQueryable<Aluguel> GetAluguels()
        {
            return db.Aluguels;
        }

        // GET: api/Alugueis/5
        [ResponseType(typeof(Aluguel))]
        public IHttpActionResult GetAluguel(int id)
        {
            Aluguel aluguel = db.Aluguels.Find(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return Ok(aluguel);
        }

        // PUT: api/Alugueis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAluguel(int id, Aluguel aluguel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluguel.id)
            {
                return BadRequest();
            }

            db.Entry(aluguel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelExists(id))
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

        // POST: api/Alugueis
        [ResponseType(typeof(Aluguel))]
        public IHttpActionResult PostAluguel(Aluguel aluguel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aluguels.Add(aluguel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aluguel.id }, aluguel);
        }

        // DELETE: api/Alugueis/5
        [ResponseType(typeof(Aluguel))]
        public IHttpActionResult DeleteAluguel(int id)
        {
            Aluguel aluguel = db.Aluguels.Find(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            db.Aluguels.Remove(aluguel);
            db.SaveChanges();

            return Ok(aluguel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AluguelExists(int id)
        {
            return db.Aluguels.Count(e => e.id == id) > 0;
        }
    }
}