using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public interface IDataRowMapper<T>
    {
        T MapRow(DbDataReader reader);
    }
}
