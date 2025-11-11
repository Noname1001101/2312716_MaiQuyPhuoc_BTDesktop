using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    internal class BillBL
    {
        BillDA billDA = new BillDA();
        public List<Bill> GetAll()
        {
            return billDA.GetAll();
        }
    }
}
