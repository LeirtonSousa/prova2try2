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
    public class DespesasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Despesas
        public IQueryable<Despesa> GetDespesas()
        {
            return db.Despesas;
        }

        // GET: api/Despesas/5
        [ResponseType(typeof(Despesa))]
        public IHttpActionResult GetDespesa(int id)
        {
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return NotFound();
            }

            return Ok(despesa);
        }

        // PUT: api/Despesas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDespesa(int id, Despesa despesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != despesa.id)
            {
                return BadRequest();
            }

            db.Entry(despesa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespesaExists(id))
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

        // POST: api/Despesas
        [ResponseType(typeof(Despesa))]
        public IHttpActionResult PostDespesa(Despesa despesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Despesas.Add(despesa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = despesa.id }, despesa);
        }

        // DELETE: api/Despesas/5
        [ResponseType(typeof(Despesa))]
        public IHttpActionResult DeleteDespesa(int id)
        {
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return NotFound();
            }

            db.Despesas.Remove(despesa);
            db.SaveChanges();

            return Ok(despesa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DespesaExists(int id)
        {
            return db.Despesas.Count(e => e.id == id) > 0;
        }
    }
}