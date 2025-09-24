using System;
using System.Collections.Generic;

namespace Lab3
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoVaTenLot { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoCMND { get; set; }
        public bool GioiTinh { get; set; }
        public string Lop { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public List<string> MHDK { get; set; }


        public SinhVien()
        {
            MHDK = new List<string>();
        }

        public SinhVien(string mssv, string hovatenlot, string t, DateTime ngaysinh, string socmnd, bool gt, string lop, string sdt, string diachi, List<string> mhdk)
        {
            this.MSSV = mssv;
            this.HoVaTenLot = hovatenlot;
            this.Ten = t;
            this.NgaySinh = ngaysinh;
            this.SoCMND = socmnd;
            this.GioiTinh = gt;
            this.Lop = lop;
            this.SDT = sdt;
            this.DiaChi = diachi;
            this.MHDK = mhdk;
        }


    }
}
