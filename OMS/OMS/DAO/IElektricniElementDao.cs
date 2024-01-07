using OMS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.DAO
{
    public interface IElektricniElementDao : ICRUDDAO<ElektricniElement, string>
    {
        int GetCount();
        ElektricniElement FindByID(string ide);
        int Save(ElektricniElement element);

    }
}
