using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
namespace Lab3
{
    // Delegate để so sánh 2 đối tượng (trả về 0 nếu bằng nhau)
    public delegate int SoSanh(object sv1, object sv2);

    public class QuanLySinhVien
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

        //public List<SinhVien> TimKiem(string tuKhoa, KieuTim kieu)
        //{
        //    List<SinhVien> ketQua = new List<SinhVien>();

        //    tuKhoa = tuKhoa.ToLower(); // đổi về chữ thường để so sánh cho dễ

        //    foreach (SinhVien sv in dsSinhVien)
        //    {
        //        switch (kieu)
        //        {
        //            case KieuTim.TheoMSSV:
        //                if (sv.MSSV != null && sv.MSSV.ToLower().Contains(tuKhoa))
        //                    ketQua.Add(sv);
        //                break;

        //            case KieuTim.TheoTen:
        //                string hoTen = (sv.HoVaTenLot + " " + sv.Ten).ToLower();
        //                if (hoTen.Contains(tuKhoa))
        //                    ketQua.Add(sv);
        //                break;

        //            case KieuTim.TheoLop:
        //                if (sv.Lop != null && sv.Lop.ToLower().Contains(tuKhoa))
        //                    ketQua.Add(sv);
        //                break;
        //        }
        //    }

        //    return ketQua; // nếu không có kết quả thì trả về list rỗng
        //}


        // Cập nhật thông tin sinh viên theo hàm so sánh
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

        // Xóa sinh viên theo điều kiện so sánh
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

        // Kiểm tra thông tin sinh viên trước khi thêm/cập nhật
        //public bool KiemTraThongTin(SinhVien sv, out string thongBao)
        //{
        //    if (string.IsNullOrWhiteSpace(sv.MSSV))
        //    {
        //        thongBao = "Vui lòng nhập MSSV!";
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(sv.HoVaTenLot))
        //    {
        //        thongBao = "Vui lòng nhập Họ và tên lót!";
        //        return false;
        //    }

        //    if (sv.NgaySinh == DateTime.MinValue)
        //    {
        //        thongBao = "Vui lòng nhập Ngày sinh!";
        //        return false;
        //    }

        //    if (sv.NgaySinh > DateTime.Now)
        //    {
        //        thongBao = "Ngày sinh không hợp lệ (lớn hơn ngày hiện tại)!";
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(sv.SoCMND))
        //    {
        //        thongBao = "Vui lòng nhập Số CMND!";
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(sv.Ten))
        //    {
        //        thongBao = "Vui lòng nhập Tên!";
        //        return false;
        //    }
        //    if (sv.GioiTinh == null)
        //    {
        //        thongBao = "Vui lòng chọn giới tính!";
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(sv.Lop))
        //    {
        //        thongBao = "Vui lòng nhập Lớp!";
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(sv.SDT))
        //    {
        //        thongBao = "Vui lòng nhập SĐT!";
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(sv.DiaChi))
        //    {
        //        thongBao = "Vui lòng nhập Địa Chỉ!";
        //        return false;
        //    }

        //    thongBao = ""; // không có lỗi
        //    return true;
        //}

        public bool KiemTraThongTin(SinhVien sv, out string thongBao)
        {
            var kiemTra = new (bool Condition, string Message)[]
            {
        (string.IsNullOrWhiteSpace(sv.MSSV), "Vui lòng nhập MSSV!"),
        (string.IsNullOrWhiteSpace(sv.HoVaTenLot), "Vui lòng nhập Họ và tên lót!"),
        (string.IsNullOrWhiteSpace(sv.Ten), "Vui lòng nhập Tên!"),
        (sv.NgaySinh == DateTime.MinValue, "Vui lòng nhập Ngày sinh!"),
        (sv.NgaySinh > DateTime.Now, "Ngày sinh không hợp lệ (lớn hơn ngày hiện tại)!"),
        (string.IsNullOrWhiteSpace(sv.SoCMND), "Vui lòng nhập Số CMND!"),
        (sv.GioiTinh == null, "Vui lòng chọn giới tính!"),
        (string.IsNullOrWhiteSpace(sv.Lop), "Vui lòng nhập Lớp!"),
        (string.IsNullOrWhiteSpace(sv.SDT), "Vui lòng nhập SĐT!"),
        (string.IsNullOrWhiteSpace(sv.DiaChi), "Vui lòng nhập Địa chỉ!"),
            };

            foreach (var check in kiemTra)
            {
                if (check.Condition)
                {
                    thongBao = check.Message;
                    return false;
                }
            }

            thongBao = ""; // Không có lỗi
            return true;
        }

        public int TinhNamNhapHoc(string lop)
        {
            // Lấy số khóa từ 2 chữ số cuối (VD: CTK47 -> "47")
            string number = lop.Substring(lop.Length - 2);
            int khoa = int.Parse(number);
            return 1976 + khoa;
        }



        // Tạo MSSV dựa vào lớp
        public string TaoMSSV(string lop)
        {
            Random rnd = new Random();
            int namNhapHoc = TinhNamNhapHoc(lop);

            string aa = (namNhapHoc % 100).ToString("D2");
            string bb = "10";
            string ccc = rnd.Next(1, 1000).ToString("D3");

            return aa + bb + ccc;
        }





        // Tìm kiếm sinh viên theo nhiều điều kiện
        public List<SinhVien> TimKiemNhieuDieuKien(
      string mssv, string ten, string lop, string diaChi,
      string hoVaTenLot = null, string ngaySinh = null,
      string soCMND = null, string soDT = null)
        {
            var ketQua = dsSinhVien.Where(sv =>
                (string.IsNullOrEmpty(mssv) || sv.MSSV.ToLower().Contains(mssv.ToLower())) &&
                (string.IsNullOrEmpty(ten) || sv.Ten.ToLower().Contains(ten.ToLower())) &&
                (string.IsNullOrEmpty(lop) || sv.Lop.ToLower().Contains(lop.Trim().ToLower())) &&
                (string.IsNullOrEmpty(diaChi) || sv.DiaChi.ToLower().Contains(diaChi.ToLower())) &&
                (string.IsNullOrEmpty(hoVaTenLot) || sv.HoVaTenLot.ToLower().Contains(hoVaTenLot.ToLower())) &&
                (string.IsNullOrEmpty(ngaySinh) || sv.NgaySinh.ToShortDateString() == ngaySinh) &&
                (string.IsNullOrEmpty(soCMND) || sv.SoCMND.ToString().Contains(soCMND)) &&
                (string.IsNullOrEmpty(soDT) || sv.SDT.ToString().Contains(soDT))
            ).ToList();

            return ketQua;
        }




        // Đọc/Ghi file TXT
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
                    sv.MSSV = s[0].Trim();
                    sv.HoVaTenLot = s[1].Trim();
                    sv.Ten = s[2].Trim();
                    //sv.NgaySinh = DateTime.Parse(s[3]); //format ngày sinh theo MM / dd / yyyy
                    sv.NgaySinh = DateTime.ParseExact(s[3].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture); // format ngày sinh theo dd/MM/yyyy
                    sv.Lop = s[4].Trim();
                    sv.SoCMND = s[5].Trim();
                    sv.SDT = s[6].Trim();
                    sv.DiaChi = s[7].Trim();
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

        // Đọc/Ghi file XML
        public void DocTuFileXML(string filename)
        {
            // Tạo bộ giải tuần tự (serializer) cho kiểu dữ liệu List<SinhVien>
            XmlSerializer serializer = new XmlSerializer(typeof(List<SinhVien>));

            // Mở file XML bằng FileStream
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                // Deserialize (giải mã XML → List<SinhVien>)
                dsSinhVien = (List<SinhVien>)serializer.Deserialize(fs);
            }


        }

        public void GhiVaoFileXML(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SinhVien>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(fs, dsSinhVien);
            }
        }

        //Đọc/Ghi file JSON
        public void DocTuFileJSON(string tenFile)
        {
            try
            {
                if (File.Exists(tenFile))
                {
                    string json = File.ReadAllText(tenFile);
                    dsSinhVien = JsonConvert.DeserializeObject<List<SinhVien>>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đọc JSON: " + ex.Message);
            }
        }




        public void GhiVaoFileJSON(string tenFile)
        {
            try
            {
                string json = JsonConvert.SerializeObject(dsSinhVien, Formatting.Indented);
                File.WriteAllText(tenFile, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi ghi JSON: " + ex.Message);
            }
        }
    }
}
