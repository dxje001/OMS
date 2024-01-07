using OMS.Classes;
using OMS.DAO;
using OMS.DAO.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Service
{
    public class KvarService
    {
        private static readonly IKvarDao kvarDao = new KvarDaoImpl();

        public IEnumerable<Kvar> FindBYDate()
        {
            return kvarDao.FindAllByDate().ToList();
        }

        public IEnumerable<Kvar> FindAll()
        {

            return kvarDao.FindAll().ToList();
        }

     

        public Kvar FindById(int id)
        {
            return kvarDao.FindById(id);
        }

        public int InsertNewKvar(Kvar k)
        {
            return kvarDao.Save(k);
        }

        public int GetCount(string date)
        {
            return kvarDao.GetCount(date);
        }
        public int Update(Kvar kvar)
        {
            return kvarDao.Update(kvar);
        }
        
    }
}
