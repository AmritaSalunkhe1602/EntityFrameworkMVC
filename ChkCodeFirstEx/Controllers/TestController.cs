using ChkCodeFirstEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChkCodeFirstEx.Controllers
{
    public class TestController : Controller
    {
        CompanyContext cc = new CompanyContext();
        
        public ActionResult Index()
        {
            var v = from t in cc.Products
                    select new ProdVM
                    {
                        ProductId = t.ProductId,
                        ProductName = t.ProductName,
                        Count = t.ProductColors.Count()
                    };
            return View(v.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p, Int64[] chk)
        {
            this.cc.Products.Add(p);
            this.cc.SaveChanges();
            foreach (Int64 cid in chk)
            {
                ProductColor temp = new ProductColor();
                temp.ColorId = cid;
                temp.ProductId = p.ProductId;
                this.cc.ProductColors.Add(temp);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GetCheckBoxes()
        {
            var v = from t in cc.Colors
                    select new ChkClrVM
                    {
                        Value = t.ColorId,
                        Text = t.ColorName,
                        ISelected = false
                    };
            return View("_ChkColor", v.ToList());
        }
        public ActionResult GetChecked(Int64 id)
        {
            var rec = this.cc.Products.Find(id);
            var c = rec.ProductColors.Select(a => a.ColorId).ToList();
            var v = from t in cc.Colors
                    select new ChkClrVM
                    {
                        Value = t.ColorId,
                        Text = t.ColorName,
                        ISelected = c.Contains(t.ColorId)
                    };
            ViewBag.Chk = v.ToList();
            return View("_ChkColor", v.ToList());
        }
        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            var rec = this.cc.Products.Find(id);
            return View(rec);
        }
        [HttpPost]
        public ActionResult Edit(Product rec, Int64[] chk)
        {
            this.cc.Entry(rec).State = System.Data.Entity.EntityState.Modified;
            this.cc.SaveChanges();
            var pclr = this.cc.ProductColors.Where(p => p.ProductId == rec.ProductId).ToList();
            foreach (var c in pclr)
            {
                this.cc.ProductColors.Remove(c);
            }
            foreach (Int64 cid in chk)
            {
                ProductColor temp = new ProductColor();
                temp.ColorId = cid;
                temp.ProductId = rec.ProductId;
                this.cc.ProductColors.Add(temp);
            }
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var rec = cc.Products.Find(id);
            var clr = rec.ProductColors.Select(pc => pc.Color.ColorName).ToList();
            ViewBag.chkclr = clr;
            return View(rec);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Deleterec(int id)
        {
            var rec = cc.Products.Find(id);
            cc.Products.Remove(rec);
            cc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int64 id)
        {
             var rec = cc.Products.Find(id);
            var clr = rec.ProductColors.Select(p => p.Color.ColorName).ToList();
            ViewBag.chkclr = clr;
            return View(rec);
        }

    }
}


