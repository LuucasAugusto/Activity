using MySql.Data.MySqlClient;

namespace ActivityStudents.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly Database dataBase;

        public RepositoryBase(Database dataBase)
        {
            this.dataBase = dataBase;
        }

        public MySqlConnection Connection { get { return new MySqlConnection(dataBase.ConnectionString); } }
    }
}
