using Microsoft.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public static class ApplicationConstants
    {
        public static readonly string CONNECTION_STRING = new SqlConnectionStringBuilder()
        {
            DataSource = "(localdb)\\mssqllocaldb",
            InitialCatalog = "JOB_PORTAL_DB",
            IntegratedSecurity = true
        }.ConnectionString;
    }
}
