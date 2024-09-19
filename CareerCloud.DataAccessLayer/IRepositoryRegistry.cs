using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.DataAccessLayer
{
    public interface IRepositoryRegistry<T>
    {
        IRepository GetRepository(T id);
    }
}
