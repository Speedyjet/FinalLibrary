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
    builder.EntitySet<CATEGORY>("CATEGORies");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CATEGORiesController : ODataController
    {
        private BookModel db = new BookModel();

        // GET: odata/CATEGORies
        [EnableQuery]
        public IQueryable<CATEGORY> GetCATEGORies()
        {
            return db.CATEGORies;
        }

        // GET: odata/CATEGORies(5)
        [EnableQuery]
        public SingleResult<CATEGORY> GetCATEGORY([FromODataUri] int key)
        {
            return SingleResult.Create(db.CATEGORies.Where(cATEGORY => cATEGORY.CATEGORYID == key));
        }

        // PUT: odata/CATEGORies(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<CATEGORY> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CATEGORY cATEGORY = db.CATEGORies.Find(key);
            if (cATEGORY == null)
            {
                return NotFound();
            }

            patch.Put(cATEGORY);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CATEGORYExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cATEGORY);
        }

        // POST: odata/CATEGORies
        public IHttpActionResult Post(CATEGORY cATEGORY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CATEGORies.Add(cATEGORY);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CATEGORYExists(cATEGORY.CATEGORYID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(cATEGORY);
        }

        // PATCH: odata/CATEGORies(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<CATEGORY> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CATEGORY cATEGORY = db.CATEGORies.Find(key);
            if (cATEGORY == null)
            {
                return NotFound();
            }

            patch.Patch(cATEGORY);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CATEGORYExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(cATEGORY);
        }

        // DELETE: odata/CATEGORies(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            CATEGORY cATEGORY = db.CATEGORies.Find(key);
            if (cATEGORY == null)
            {
                return NotFound();
            }

            db.CATEGORies.Remove(cATEGORY);
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

        private bool CATEGORYExists(int key)
        {
            return db.CATEGORies.Count(e => e.CATEGORYID == key) > 0;
        }
    }
}
