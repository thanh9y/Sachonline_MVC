using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=THANHSA9Y\\SQLEXPRESS;Initial Catalog=SachOnline;Integrated Security=True");
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACHHANG kh)
        {
            //Gan cac gia tri nguoi dung nhap du lieu cho cac bien
            var sHoTen = collection["HoTen"];
            var sTenDN = collection["TenDN"];
            var sMatkhau = collection["Matkhau"];
            var sMatkhauNhapLai = collection["MatKhauNL"];
            var sDiaChi = collection["DiaChi"];
            var sEmail = collection["Email"];
            var sDienThoai = collection["DienThoai"];
            var dNgaySinh = String.Format("{0:MM/dd/yyyy}", collection["NgaySinh"]);
            if (String.IsNullOrEmpty(sHoTen))
            {
                ViewData["err1"] = "Họ tên không được rỗng";
            }

            else if (String.IsNullOrEmpty(sTenDN))
            {
                ViewData["err2"] = "Tên đăng nhập không được rỗng";
            }

            else if (String.IsNullOrEmpty(sMatkhau))
            {
                ViewData["err3"] = "Phải nhập lại mật khẩu";
            }
            else if (String.IsNullOrEmpty(sMatkhauNhapLai))
            {
                ViewData["err4"] = "Phải nhập lại mật khẩu";
            }

            else if (sMatkhau != sMatkhauNhapLai)
            {
                ViewData["err4"] = "Mật khẩu nhập lại không khớp";
            }

            else if (String.IsNullOrEmpty(sEmail))
            {
                ViewData["err5"] = "Email không được rổng";
            }

            else if (String.IsNullOrEmpty(sDienThoai))
            {
                ViewData["err6"] = "Số điện thoại không được rỗng";
            }

            else if (data.KHACHHANGs.SingleOrDefault(n => n.TaiKhoan == sTenDN) != null)
            {
                ViewBag.ThongBao = "Tên đăng nhập đã tồn tại";
            }

            else if (data.KHACHHANGs.SingleOrDefault(n => n.Email == sEmail) != null)
            {
                ViewBag.ThongBao = "Email đã được sử dụng";
            }
            else
            {
                kh.HoTen = sHoTen;
                kh.TaiKhoan = sTenDN;
                kh.MatKhau = sMatkhau;
                kh.Email = sEmail;
                kh.DiaChi = sDiaChi;
                kh.DienThoai = sDienThoai;
                kh.NgaySinh = DateTime.Parse(dNgaySinh);
                data.KHACHHANGs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var sTenDN = collection["TenDN"];
            var sMatkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(sTenDN))
            {
                ViewData["Err1"] = "Bạn chưa nhập tên đăng nhập";
            }

            else if (String.IsNullOrEmpty(sMatkhau))
            {
                ViewData["Err2"] = "Phải nhập mật khẩu";
            }
            else
            {
                KHACHHANG kh = data.KHACHHANGs.SingleOrDefault(n => n.TaiKhoan == sTenDN && n.MatKhau == sMatkhau);
                if (kh != null)
                {
                    ViewBag.ThongBao = "Chúc mừng đăng nhập nhành công";
                    Session["TaiKhoan"] = kh;

                }
                else
                {
                    Session["TaiKhoan"] = kh;
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
                
            }
            return View();
        }
    }
}