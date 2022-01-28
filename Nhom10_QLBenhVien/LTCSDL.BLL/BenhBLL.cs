using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTCSDL.DAL;
using LTCSDL.DTO;

namespace LTCSDL.BLL
{
    public class BenhBLL
    {
        private BenhDAL dal;

        public BenhBLL()
        {
            dal = new BenhDAL();
        }

        public List<Benh> GetAll()
        {
            return dal.GetAll();
        }
    }
}
