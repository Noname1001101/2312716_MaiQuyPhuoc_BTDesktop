using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap3
{
    internal class TinhToan
    {
        public static void TachChuoi(string hoten, ref string s1, ref string s2)
        {
            string[] tach = hoten.Split(' ');
            if (tach.Length >= 2)
            {
                s1 = tach[0];
                s2 = tach[1];
            }
            else
            {
                // Nếu không có khoảng trắng
                s1 = "";
                s2 = hoten;
            }

        }

        public static bool ThuTu(ref int n1, ref int n2)
        {
            if (n2 == n1 + 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
