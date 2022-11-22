using System.Data;
using System.Data.SqlClient;

namespace DemoAppWeb
{
    public class InnovationRepository
    {
        private readonly string _connectionString;

        public InnovationRepository(IConfiguration configuration)
        {
            var server = configuration["Server"];
            var port = configuration["Port"];
            var database = configuration["Database"];
            var user = configuration["User"];
            var password = configuration["Password"];
            _connectionString = $"Server={server},{port};Database={database};User={user};Password={password};Integrated Security=False;";
            //_connectionString = configuration.GetConnectionString("InnovationManagement");
        }

        public async Task<List<DepartmentIdea>> GetDepartmentIdeasAsync()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, DepartmentName, Idea, Author FROM DepartmentIdeas";

            var departments = new List<DepartmentIdea>();

            await connection.OpenAsync();

            using (var reader = command.ExecuteReader())
            {
                while (await reader.ReadAsync())
                {
                    DepartmentIdea department = new DepartmentIdea()
                    {
                        Id = reader.GetInt32(0),
                        DepartmentName = reader.GetString(1),
                        Idea = reader.GetString(2),
                        Author = reader.GetString(3),
                    };

                    departments.Add(department);
                }
            }

            await connection.CloseAsync();

            return departments;
        }

        public async Task<DepartmentIdea> GetDepartmentIdeaAsync(int id)
        {

            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT TOP(1) Id, DepartmentName, Idea, Author FROM DepartmentIdeas WHERE Id = {id}";

            DepartmentIdea departmentIdea = new DepartmentIdea();

            await connection.OpenAsync();

            using (var reader = command.ExecuteReader())
            {
                while (await reader.ReadAsync())
                {
                    departmentIdea = new DepartmentIdea()
                    {
                        Id = reader.GetInt32(0),
                        DepartmentName = reader.GetString(1),
                        Idea = reader.GetString(2),
                        Author = reader.GetString(3),
                    };
                }
            }

            await connection.CloseAsync();

            return departmentIdea;
        }

        public async Task DeleteDepartmentIdeaAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "DELETE FROM DepartmentIdeas WHERE Id = @param1";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.Int).Value = id;
                    cmd.CommandType = CommandType.Text;
                    await cmd.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
        }

        public async Task SaveDepartmentIdeaAsync(DepartmentIdea department)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "INSERT INTO DepartmentIdeas (DepartmentName, Idea, Author) VALUES (@param1,@param2,@param3)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 50).Value = department.DepartmentName;
                    cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 100).Value = department.Idea;
                    cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = department.Author;
                    cmd.CommandType = CommandType.Text;
                    await cmd.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
        }
    }
}
