using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap3
{
    internal class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen{ get; set; }
        public string NgaySinh { get; set; }
        public double HeSoLuong { get; set; }
        public double HeSoPhuCap {  get; set; }

        public NhanVien(string maNV, string hoTen, string ngaySinh, double heSoLuong, double heSoPhuCap ) 
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.HeSoLuong = heSoLuong;
            this.HeSoPhuCap = heSoPhuCap;
        }

        public double TongLuong()
        {
            return (HeSoLuong + HeSoPhuCap) * 1150000;
        }

        public string HienThi()
        {
            return string.Format("{0}, {1}, {2}, {3}", MaNV, HoTen, NgaySinh, TongLuong());
        }
    }
}
