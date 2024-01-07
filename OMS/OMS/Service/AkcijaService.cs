using iText.StyledXmlParser.Node;
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
    public class AkcijaService
    {
        private static readonly IAkcijaDao akcijaDao = new AkciaDaoImpl();

        public List<Akcija> GetAll(string kvarid)
        {
            return akcijaDao.GetAll(kvarid).ToList();
        }
        public int GetCount(string kvarid)
        {
            return akcijaDao.GetCount(kvarid);
        }
    }
}
