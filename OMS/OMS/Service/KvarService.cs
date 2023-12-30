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

        public List<Kvar> FindBYDate()
        {
            return kvarDao.FindAllByDate.ToList();
        }

        public List<Kvar> FindAll()
        {
            return kvarDao.FindAll().ToList();
        }

        public Kvar FindById(string? id)
        {
            return kvarDao.FindById(id);
        }
    }
}
