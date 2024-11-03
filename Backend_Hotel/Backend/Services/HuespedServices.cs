using Dapper;

using System.Data;
using Backend.Models;
using Backend.Controllers;
using MySql.Data.MySqlClient;

namespace Backend.Services
{
    public class HuespedServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public HuespedServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MyDB")!;
        }

        //-------------------Get------------------------------
        public async Task<Huesped> GetHuesped(int id)
        {
            string queryCommand = "sp_ObtenerHuesped";
            var parameters = new DynamicParameters();
            parameters.Add("@idToObtener", id, DbType.Int32);

            using (var con = new MySqlConnection(_connectionString))
            {
                var huesped = await con.QueryFirstOrDefaultAsync<Huesped>(
                    queryCommand, parameters, commandType: CommandType.StoredProcedure);
                return huesped;
            }
        }

        //-------------------Post------------------------------
        public async Task<string> PostHuesped(Huesped huesped)
        {
            string queryCommand = "sp_InsertarHuesped";
            var parameters = new DynamicParameters();
            parameters.Add("@nombres", huesped.Nombres, DbType.String);
            parameters.Add("@apellidos", huesped.Apellidos, DbType.String);
            parameters.Add("@email", huesped.Email, DbType.String);
            parameters.Add("@telefono", huesped.Telefono, DbType.String);
            parameters.Add("@direccion", huesped.Direccion, DbType.String);

            using (var con = new MySqlConnection(_connectionString))
            {
                await con.ExecuteAsync(queryCommand, parameters, commandType: CommandType.StoredProcedure);
            }

            return "Huesped registrado";
        }

        //-------------------Put------------------------------
        public async Task<bool> PutHuesped(Huesped huesped)
        {
            string queryCommand = "sp_ActualizarHuesped";
            var parameters = new DynamicParameters();
            parameters.Add("@idO", huesped.IdHuesped, DbType.Int32);
            parameters.Add("@Nombres", huesped.Nombres, DbType.String);
            parameters.Add("@Apellidos", huesped.Apellidos, DbType.String);
            parameters.Add("@Email", huesped.Email, DbType.String);
            parameters.Add("@Telefono", huesped.Telefono, DbType.String);
            parameters.Add("@Direccion", huesped.Direccion, DbType.String);

            using (var con = new MySqlConnection(_connectionString))
            {
                var result = await con.ExecuteAsync(queryCommand, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        //-------------------Delete------------------------------
        public async Task<bool> DeleteHuesped(int id)
        {
            string queryCommand = "sp_EliminarHuesped";
            var parameters = new DynamicParameters();
            parameters.Add("@idToDelete", id, DbType.Int32);

            using (var con = new MySqlConnection(_connectionString))
            {
                var result = await con.ExecuteAsync(queryCommand, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
