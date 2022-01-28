using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTCSDL.DAL;
using LTCSDL.DTO;


namespace LTCSDL.BLL
{
    public class ThuocBLL
    {
        private ThuocDAL dal;

        public ThuocBLL()
        {
            dal = new ThuocDAL();
        }

        public List<Thuocx> GetAll()
        {
            return dal.GetAll();
        }
    }
}
