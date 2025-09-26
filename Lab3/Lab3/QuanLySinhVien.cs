using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace Lab3
{
    public delegate int SoSanh(object sv1, object sv2);
    public enum KieuTim
    {
        TheoMSSV,
        TheoTen,
        TheoLop
    }
    class QuanLySinhVien
    {
        public List<SinhVien> dsSinhVien;


        public QuanLySinhVien()
        {
            dsSinhVien = new List<SinhVien>();
        }

        public SinhVien this[int index]
        {
            get { return this.dsSinhVien[index]; }
            set { this.dsSinhVien[index] = value; }
        }

        public void Them(SinhVien sv)
        {
            this.dsSinhVien.Add(sv);
        }

        public List<SinhVien> TimKiem(string tuKhoa, KieuTim kieu)
        {
            List<SinhVien> ketQua = new List<SinhVien>();

            tuKhoa = tuKhoa.ToLower(); // đổi về chữ thường để so sánh cho dễ

            foreach (SinhVien sv in dsSinhVien)
            {
                switch (kieu)
                {
                    case KieuTim.TheoMSSV:
                        if (sv.MSSV != null && sv.MSSV.ToLower().Contains(tuKhoa))
                            ketQua.Add(sv);
                        break;

                    case KieuTim.TheoTen:
                        string hoTen = (sv.HoVaTenLot + " " + sv.Ten).ToLower();
                        if (hoTen.Contains(tuKhoa))
                            ketQua.Add(sv);
                        break;

                    case KieuTim.TheoLop:
                        if (sv.Lop != null && sv.Lop.ToLower().Contains(tuKhoa))
                            ketQua.Add(sv);
                        break;
                }
            }

            return ketQua; // nếu không có kết quả thì trả về list rỗng
        }



        public bool CapNhat(SinhVien svsua, object obj, SoSanh ss)
        {
            for (int i = 0; i < this.dsSinhVien.Count; i++)
            {
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    return true;
                }
            }
            return false;
        }

        public void Xoa(object obj, SoSanh ss)
        {
            int i = dsSinhVien.Count - 1;
            for (; i >= 0; i--)
            {
                if (ss(obj, this[i]) == 0)
                {
                    this.dsSinhVien.RemoveAt(i);
                }
            }
        }

        public bool KiemTraThongTin(SinhVien sv, out string thongBao)
        {
            if (string.IsNullOrWhiteSpace(sv.MSSV))
            {
                thongBao = "Vui lòng nhập MSSV!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(sv.HoVaTenLot))
            {
                thongBao = "Vui lòng nhập Họ và tên lót!";
                return false;
            }

            if (sv.NgaySinh == DateTime.MinValue)
            {
                thongBao = "Vui lòng nhập Ngày sinh!";
                return false;
            }

            if (sv.NgaySinh > DateTime.Now)
            {
                thongBao = "Ngày sinh không hợp lệ (lớn hơn ngày hiện tại)!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.SoCMND))
            {
                thongBao = "Vui lòng nhập Số CMND!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.Ten))
            {
                thongBao = "Vui lòng nhập Tên!";
                return false;
            }
            if (sv.GioiTinh == null)
            {
                thongBao = "Vui lòng chọn giới tính!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.Lop))
            {
                thongBao = "Vui lòng nhập Lớp!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.SDT))
            {
                thongBao = "Vui lòng nhập SĐT!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sv.DiaChi))
            {
                thongBao = "Vui lòng nhập Địa Chỉ!";
                return false;
            }

            thongBao = ""; // không có lỗi
            return true;
        }



        public string TaoMSSV(string lop)
        {
            Random rnd = new Random();

            // Lấy 2 số cuối của lớp (ví dụ CTK47 -> "47")
            string aa = lop.Substring(lop.Length - 2);

            // BB = 10
            string bb = "10";

            // Sinh số random từ 1 đến 999, rồi format thành 3 chữ số
            int soNgauNhien = rnd.Next(1, 1000);
            string ccc = soNgauNhien.ToString("D3");

            return aa + bb + ccc;
        }


        public void DocTuFile(string filename)
        {
            string t;
            string[] s;
            SinhVien sv;
            using (StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open)))
            {
                while ((t = sr.ReadLine()) != null)
                {
                    s = t.Split(',');
                    sv = new SinhVien();
                    sv.MSSV = s[0];
                    sv.HoVaTenLot = s[1];
                    sv.Ten = s[2];
                    //sv.NgaySinh = DateTime.Parse(s[3]); //format ngày sinh theo MM / dd / yyyy
                    sv.NgaySinh = DateTime.ParseExact(s[3].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture); // format ngày sinh theo dd/MM/yyyy
                    sv.Lop = s[4];
                    sv.SoCMND = s[5];
                    sv.SDT = s[6];
                    sv.DiaChi = s[7];
                    this.Them(sv);
                }
            }
        }


        public void GhiVaoFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(filename, FileMode.Create)))
            {
                foreach (SinhVien sv in dsSinhVien)
                {
                    string line = string.Join(",",
                        sv.MSSV,
                        sv.HoVaTenLot,
                        sv.Ten,
                        sv.NgaySinh.ToString("dd/MM/yyyy"),
                        sv.Lop,
                        sv.SoCMND,
                        sv.SDT,
                        sv.DiaChi
                    );
                    sw.WriteLine(line);
                }
            }
        }



    }
}
