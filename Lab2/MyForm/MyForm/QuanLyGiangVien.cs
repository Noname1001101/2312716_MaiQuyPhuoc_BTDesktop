using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public delegate int SoSanhGiangVien(object a, object b);
    public enum KieuTim
    {
        TheoMa,
        TheoHoTen,
        TheoSDT
    }

    public class QuanLyGiangVien
    {

        public List<GiangVien> dsGiangVien;
        public QuanLyGiangVien() 
        {
            dsGiangVien = new List<GiangVien>();
        }

        public GiangVien this[int index]
        {
            get { return dsGiangVien[index]; }
            set { dsGiangVien[index] = value; }
        }

        public void SapXep(SoSanhGiangVien ssgv)
        {
            this.dsGiangVien.Sort((a, b) => ssgv(a, b));
        }

  

        public bool Them(GiangVien gv)
        {
            // Kiểm tra trùng mã số
            if (!dsGiangVien.Any(x => x.MaSo == gv.MaSo))
            {
                dsGiangVien.Add(gv);
                return true;
            }
            return false;
        }

        public GiangVien Tim(string tuKhoa, KieuTim kieu)
        {
            tuKhoa = tuKhoa.Trim().ToLower();

            switch (kieu)
            {
                case KieuTim.TheoMa:
                    return dsGiangVien.FirstOrDefault(g => g.MaSo.ToLower() == tuKhoa);

                case KieuTim.TheoHoTen:
                    return dsGiangVien.FirstOrDefault(g => g.HoTen.ToLower().Contains(tuKhoa));

                case KieuTim.TheoSDT:
                    return dsGiangVien.FirstOrDefault(g => g.SoDT.ToLower().Contains(tuKhoa));


                default:
                    return null;
            }
        }



        public GiangVien Xoa(string keyword, KieuTim kieu)
        {
            for (int i = 0; i < dsGiangVien.Count; i++)
            {
                switch (kieu)
                {
                    case KieuTim.TheoMa:
                        if (dsGiangVien[i].MaSo == keyword)
                        {
                            GiangVien gv = dsGiangVien[i];
                            dsGiangVien.RemoveAt(i);
                            return gv;
                        }
                        break;

                    case KieuTim.TheoHoTen:
                        if (dsGiangVien[i].HoTen == keyword)
                        {
                            GiangVien gv = dsGiangVien[i];
                            dsGiangVien.RemoveAt(i);
                            return gv;
                        }
                        break;

                    case KieuTim.TheoSDT:
                        if (dsGiangVien[i].SoDT == keyword)
                        {
                            GiangVien gv = dsGiangVien[i];
                            dsGiangVien.RemoveAt(i);
                            return gv;
                        }
                        break;
                }
            }
            return null;
        }
    }

}

    