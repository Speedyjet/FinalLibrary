using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using FinalLibrary.Models;

namespace FinalLibrary.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using FinalLibrary.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<BOOK>("BOOKs");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BOOKsController : ODataController
    {
        private BookModel db = new BookModel();

        // GET: odata/BOOKs
        [EnableQuery]
        public IQueryable<BOOK> GetBOOKs()
        {
            return db.BOOKS;
        }

        // GET: odata/BOOKs(5)
        [EnableQuery]
        public SingleResult<BOOK> GetBOOK([FromODataUri] int key)
        {
            return SingleResult.Create(db.BOOKS.Where(bOOK => bOOK.BOOKID == key));
        }

        // PUT: odata/BOOKs(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<BOOK> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BOOK bOOK = db.BOOKS.Find(key);
            if (bOOK == null)
            {
                return NotFound();
            }

            patch.Put(bOOK);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOOKExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bOOK);
        }

        // POST: odata/BOOKs
        public IHttpActionResult Post(BOOK bOOK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BOOKS.Add(bOOK);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BOOKExists(bOOK.BOOKID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(bOOK);
        }

        // PATCH: odata/BOOKs(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<BOOK> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BOOK bOOK = db.BOOKS.Find(key);
            if (bOOK == null)
            {
                return NotFound();
            }

            patch.Patch(bOOK);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOOKExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bOOK);
        }

        // DELETE: odata/BOOKs(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            BOOK bOOK = db.BOOKS.Find(key);
            if (bOOK == null)
            {
                return NotFound();
            }

            db.BOOKS.Remove(bOOK);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BOOKExists(int key)
        {
            return db.BOOKS.Count(e => e.BOOKID == key) > 0;
        }
    }
}
