using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.DAO
{
    public interface ICRUDDAO<T, ID> 
    {
        IEnumerable<T> FindAll();

        IEnumerable<T> FindAllByDate();
        T FindById(ID id);
        int Save(T entity);
    }
}
