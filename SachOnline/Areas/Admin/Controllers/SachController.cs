using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;


namespace SachOnline.Areas.Admin.Controllers
{
    public class SachController : Controller
    {
        dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=THANHSA9Y\\SQLEXPRESS;Initial Catalog=SachOnline;Integrated Security=True");
        // GET: Admin/Sach
        public ActionResult Index( int ? page)
        {
            int iPageNum = (page ?? 1);
            int iPageSize = 7;
            return View(data.SACHes.ToList().OrderBy(n=>n.MaSach).ToPagedList(iPageNum,iPageSize));
        }

        [HttpGet]
        public ActionResult Create() 
        {
            ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View();
        }
    }
}