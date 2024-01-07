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
    public class ElektricniElementService
    {
        private static readonly IElektricniElementDao elektricniElementDao = new ElektricniElementDaoImpl();

        public int Save(ElektricniElement elektricniElement)
        {
            return elektricniElementDao.Save(elektricniElement);
        }

        public int GetCount()
        {
            return elektricniElementDao.GetCount();
        }
        public ElektricniElement FindById(string ide)
        {
            return elektricniElementDao.FindByID(ide);
        }
    }
}
