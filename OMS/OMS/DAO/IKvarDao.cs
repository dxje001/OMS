using OMS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.DAO
{
    public interface IKvarDao : ICRUDDAO<Kvar,string>
    {
        IEnumerable<Kvar> FindAllByDate();
        IEnumerable<Kvar> FindAll();
        Kvar FindById(int id);
        int GetCount(string date);
        int Update(Kvar kvar);
        int Save(Kvar kvar);

    }
}
