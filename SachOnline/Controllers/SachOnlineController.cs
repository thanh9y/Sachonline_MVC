﻿using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Web.UI;


namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {

        dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=THANHSA9Y\\SQLEXPRESS;Initial Catalog=SachOnline;Integrated Security=True");
        // GET: SachOnline
       
        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);


            ViewBag.ListSachMoi = listSachMoi;


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
            var listSachBanNhieu = LaySachBanNhieu(6);
            return PartialView(listSachBanNhieu);
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
        public ActionResult SachTheoChuDe(int iMaCD, int ? page )
        {
            ViewBag.MaCD = iMaCD;
            int iSize = 3;
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaCD ==iMaCD select s;
            return View(sach.ToPagedList(iPageNum,iSize));
        }
         public ActionResult SachTheoNXB(int iMaNXB, int? page)
         {
            ViewBag.MaNXB = iMaNXB;
            int iSize = 3;
            int iPageNum = (page ?? 1);
            var sach = from s in data.SACHes where s.MaNXB == iMaNXB select s;
             return View(sach.ToPagedList(iPageNum, iSize));
        }
        public ActionResult ChiTietSach (int id)
        {
            var sach = from s in data.SACHes where s.MaSach == id select s;
            return View(sach.Single());
        }
        public ActionResult LoginLogout()
        {

            return PartialView();
        }

    }
}