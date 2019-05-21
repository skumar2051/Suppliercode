using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SuppliersAPI.Models;
using System.Data.Entity;
namespace SuppliersAPI.Controllers
{
    public class SupplierController : ApiController
    {
        PODbEntities db = new PODbEntities();

        public IHttpActionResult Get()
        {
            return Ok(db.SUPPLIERs.ToArray());
        }

        public IHttpActionResult Get(string id)
        {
            if (id==null)
            {
                return BadRequest("Invalid supplier no");
            }
                var obj = db.SUPPLIERs.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        public IHttpActionResult Post(SUPPLIER obj)
        {
            db.SUPPLIERs.Add(obj);
            int NoOfRowsAffected = db.SaveChanges();
            if(NoOfRowsAffected>0)
            {
                return StatusCode(HttpStatusCode.Created);
            }
            {
                return BadRequest("Failed to add supplier");
            }
        }

        public IHttpActionResult Put(SUPPLIER obj)

        {
            db.SUPPLIERs.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            var NoOfRowsAffected= db.SaveChanges();
            if (NoOfRowsAffected > 0)
            {
                return StatusCode(HttpStatusCode.Accepted);
            }
            else {
                return BadRequest("failed to update supplier");


            }
        }

        public IHttpActionResult Delete(string id)
        {
            var obj = db.SUPPLIERs.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            db.SUPPLIERs.Remove(obj);
            var NoOfRowsAffected = db.SaveChanges();
            if(NoOfRowsAffected>0)
            {
                return StatusCode(HttpStatusCode.NoContent);

            }
            else
            {
                return BadRequest("Failed to Delete");
            }
        }

        
    }
}
