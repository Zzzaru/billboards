using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Billboards.Models.EF;

namespace Billboards.Controllers
{
    public class HomeController : Controller
    {
        private readonly BillboardContext _db = new BillboardContext();

        public ActionResult Index()
        {
            return View(_db.Billboards.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillboardE billboardE = _db.Billboards.Find(id);
            if (billboardE == null)
            {
                return HttpNotFound();
            }
            return View(billboardE);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,MaintenanceTime,Location,Type,Heigh,Width,MonthlyCost")] BillboardE billboardE)
        {
            if (ModelState.IsValid)
            {
                _db.Billboards.Add(billboardE);
                _db.Entry(billboardE).State = EntityState.Added;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billboardE);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillboardE billboardE = _db.Billboards.Find(id);
            if (billboardE == null)
            {
                return HttpNotFound();
            }
            return View(billboardE);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Description,MaintenanceTime,Location,Type,Heigh,Width,MonthlyCost")] BillboardE billboardE)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(billboardE).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billboardE);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillboardE billboardE = _db.Billboards.Find(id);
            if (billboardE == null)
            {
                return HttpNotFound();
            }
            return View(billboardE);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillboardE billboardE = _db.Billboards.Find(id);
            _db.Billboards.Remove(billboardE);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
