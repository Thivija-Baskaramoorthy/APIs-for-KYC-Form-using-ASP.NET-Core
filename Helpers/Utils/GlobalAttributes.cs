 namespace InternKYCApplication.Helpers.Utils
{
    public class GlobalAttributes
    {
        public static MySQLConfiguration mysqlConfiguration = new MySQLConfiguration();
    }

    public class MySQLConfiguration
    {
        public string connectionString { get; set; }
    }
}

