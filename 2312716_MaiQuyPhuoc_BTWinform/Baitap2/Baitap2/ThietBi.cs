using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Baitap2
{
    internal class ThietBi
    {
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string NuocSanXuat { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }

        public ThietBi(string maTB, string tenTB,string nuocSX, int donGia, int soLuong) 
        {
            this.MaThietBi = maTB;
            this.TenThietBi = tenTB;
            this.NuocSanXuat = nuocSX;
            this.DonGia = donGia;
            this.SoLuong = soLuong;
        }

      
        public  int ThanhTien()
        {
            return DonGia * SoLuong;
        }

        public string HienThi()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}",MaThietBi, TenThietBi, NuocSanXuat,DonGia,SoLuong,ThanhTien());
        }


    }
}
