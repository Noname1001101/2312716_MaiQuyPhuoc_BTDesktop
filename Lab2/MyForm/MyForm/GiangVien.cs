using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    internal class GiangVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public DanhSachHocPhan dsHocPhan;
        public string[] NgoaiNgu;
        public string GioiTinh;
        public string Mail;
        public string SoDT;

        public GiangVien()
        {
            dsHocPhan = new DanhSachHocPhan();
            NgoaiNgu = new string[20]; 
        }

        public GiangVien(string maso, string hoten, DateTime ngaysinh, DanhSachHocPhan ds, string[] nn, string gt, string mail, string sdt)
        {
            this.MaSo = maso;
            this.HoTen = hoten;
            this.NgaySinh = ngaysinh;
            this.dsHocPhan = ds;
            this.NgoaiNgu = nn;
            this.GioiTinh = gt;
            this.Mail = mail;
            this.SoDT = sdt;
        }

        public override string ToString()
        {
            string s = "Mã số: " + MaSo + "\n"
                + "Họ tên: " + HoTen + "\n"
                + "Ngày sinh: " + NgaySinh + "\n"
                + "Giới tính: " + GioiTinh + "\n"
                + "Số ĐT: " + SoDT + "\n"
                + "Mail: " + Mail + "\n";
            string sngoaingu = "Ngoại ngữ";
            foreach (string t in NgoaiNgu)
            {
                sngoaingu += t + ";";
            }
            string monDay = "Danh sách môn dạy: ";
            foreach (HocPhan hp in dsHocPhan.ds)
            {
                monDay += hp + ";";

            }
            s += "\n" + sngoaingu + "\n" + monDay;
            return s;

        }
    }
}
