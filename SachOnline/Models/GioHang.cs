using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SachOnline.Models
{
    public class GioHang
    {
        dbSachOnlineDataContext data = new dbSachOnlineDataContext("Data Source=THANHSA9Y\\SQLEXPRESS;Initial Catalog=SachOnline;Integrated Security=True");
        public int iMaSach { get; set; }
        public string sTenSach { get; set;}
        public string sAnhBia { get; set; }
        public double dDongGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien 
        { 
            get { return iSoLuong * dDongGia; }
        }
        public GioHang(int ms) 
        {
            iMaSach = ms;
            SACH s = data.SACHes.Single(n => n.MaSach == iMaSach);
            sTenSach = s.TenSach;
            sAnhBia = s.AnhBia;
            dDongGia = double.Parse(s.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}