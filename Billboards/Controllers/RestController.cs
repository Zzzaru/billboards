using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Billboards.Models.EF;

namespace Billboards.Controllers
{
    public class RestController : ApiController
    {
        private readonly BillboardContext _db = new BillboardContext();

        // GET: api/Rest
        public IQueryable<BillboardE> GetBillboards()
        {
            return _db.Billboards;
        }

        // GET: api/Rest/5
        [ResponseType(typeof(BillboardE))]
        public IHttpActionResult GetBillboardE(int id)
        {
            BillboardE billboardE = _db.Billboards.Find(id);
            if (billboardE == null)
            {
                return NotFound();
            }

            return Ok(billboardE);
        }

        // PUT: api/Rest/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBillboardE(int id, BillboardE billboardE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != billboardE.Id)
            {
                return BadRequest();
            }

            _db.Entry(billboardE).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillboardEExists(id))
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

        // POST: api/Rest
        [ResponseType(typeof(BillboardE))]
        public IHttpActionResult PostBillboardE(BillboardE billboardE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Billboards.Add(billboardE);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = billboardE.Id }, billboardE);
        }

        // DELETE: api/Rest/5
        [ResponseType(typeof(BillboardE))]
        public IHttpActionResult DeleteBillboardE(int id)
        {
            BillboardE billboardE = _db.Billboards.Find(id);
            if (billboardE == null)
            {
                return NotFound();
            }

            _db.Billboards.Remove(billboardE);
            _db.SaveChanges();

            return Ok(billboardE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BillboardEExists(int id)
        {
            return _db.Billboards.Count(e => e.Id == id) > 0;
        }
    }
}