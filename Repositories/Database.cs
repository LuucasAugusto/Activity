namespace ActivityStudents.Repositories
{
    public class Database
    {
        public Database(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
