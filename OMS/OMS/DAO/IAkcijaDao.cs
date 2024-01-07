using OMS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.DAO
{
    public interface IAkcijaDao : ICRUDDAO<Akcija,int>
    {
        public List<Akcija> GetAll(string kvarid);
        public int GetCount(string kvarid);
    }
}
