using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {

        dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=THANHSA9Y\\SQLEXPRESS;Initial Catalog=SachOnline;Integrated Security=True");
        // GET: SachOnline
       
        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);
            var listSachBanNhieu = LaySachBanNhieu(6);

            ViewBag.ListSachMoi = listSachMoi;
            ViewBag.ListSachBanNhieu = listSachBanNhieu;

            return View();
        }
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult NhaXuatBanPartial()
        {
            var NhaXuatBan = from cd in data.NHAXUATBANs select cd;
            return PartialView(NhaXuatBan);
        }

        public ActionResult NavPartial()
        {
            return PartialView();
        }

        public ActionResult FooterPartial()
        {
            return PartialView();
        }

        public ActionResult SachBanNhieuPartial()
        {
            return PartialView();
        }

        public ActionResult SliderPartial()
        {
            return PartialView();
        }
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        private List<SACH> LaySachBanNhieu(int count)
        {
            return data.SACHes.OrderByDescending(a => a.SoLuongBan).Take(count).ToList();
        }
        public ActionResult SachTheoChuDe(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return PartialView(sach);
        }
         public ActionResult SachTheoNXB(int id)
         {
             var sach = from s in data.SACHes where s.MaNXB == id select s;
             return PartialView(sach);
         }
        public ActionResult ChiTietSach (int id)
        {
            var sach = from s in data.SACHes where s.MaSach == id select s;
            return View(sach.Single());
        }
       
       
    }
}