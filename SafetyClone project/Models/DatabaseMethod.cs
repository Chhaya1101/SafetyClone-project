using Microsoft.Data.SqlClient;
using System.Data;

namespace SafetyClone_project.Models
{
    
    public class DatabaseMethod
    {
        private readonly string connectionString;

        public DatabaseMethod(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SampleDBConnection");
        }
        public async Task<DataTable> ExecuteQueryAsync(string query, SqlParameter[] parameters = null)
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    var reader = await command.ExecuteReaderAsync();

                    // Load data into the DataTable
                    dataTable.Load(reader);
                }
            }

            return dataTable;
        }
        public async Task<int> ExecuteNonQueryAsync(string query, SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected;
                }


            }

        }
        public async Task<bool> CheckExistingRecordAsync(string commandText, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(parameters);
                    //if (parameters != null)
                    //{
                    //    foreach (var param in parameters)
                    //    {
                    //        command.Parameters.Add(param);
                    //    }
                    //}

                    int count = (int)await command.ExecuteScalarAsync();

                    return count > 0;
                }
            }
        }
        public async Task<DataTable> ExecuteStoredProcedureQueryAsync(string query, SqlParameter[] parameters = null)
        {
            var resultList = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    var reader = await command.ExecuteReaderAsync();


                    resultList.Load(reader);
                }
            }

            return resultList;
        }

    }
}
