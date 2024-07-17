using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public interface IDbRowMapper<T>
    {
        T MapRow(DbDataReader reader);
    }
}
