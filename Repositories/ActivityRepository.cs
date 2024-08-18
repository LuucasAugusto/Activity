using ActivityStudents.Entities;
using Dapper;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ActivityStudents.Repositories
{
    public class ActivityRepository : RepositoryBase
    {
        public ActivityRepository(Database dataBase) : base(dataBase)
        {
        }

        public List<ActivityEntity> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();

                try
                {
                    var activities = connection.Query<ActivityEntity>("SELECT * FROM activity").ToList();

                    return activities;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ActivityEntity> GetByName(string name)
        {
            using (var connection = Connection)
            {
                connection.Open();

                try
                {
                    var sql = "SELECT * FROM activity WHERE StudentName = @StudentName";

                    var activities = connection.Query<ActivityEntity>(sql, new { StudentName = name });

                    return activities;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ActivityEntity> GetByClass(string value)
        {
            using (var connection = Connection)
            {
                connection.Open();

                try
                {
                    var sql = "SELECT * FROM activity WHERE ClassIdentify = @ClassIdentify";

                    var activities = connection.Query<ActivityEntity>(sql, new { ClassIdentify = value });

                    return activities;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        internal IEnumerable<ActivityEntity> GetByNameAndClass(string name, string classId)
        {
            using (var connection = Connection)
            {
                connection.Open();

                try
                {
                    var sql = "SELECT * FROM activity WHERE ClassIdentify = @ClassIdentify AND StudentName = @StudentName";

                    var activities = connection.Query<ActivityEntity>(sql, new { ClassIdentify = classId, StudentName = name });

                    return activities;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
