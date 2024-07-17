using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public interface IDbCommandParameterSetter<T>
    {
        void SetValues(DbCommand cmd, T item);
    }
}
