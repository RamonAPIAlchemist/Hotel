using Dapper;
using Backend.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Backend.Services
{
    public class ReservaServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ReservaServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MyDB")!;
        }

        //-------------------Get------------------------------
        public async Task<Reserva> GetReserva(int id)
        {
            string queryCommand = "sp_ObtenerReserva";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32);

            using (var con = new MySqlConnection(_connectionString))
            {
                var reserva = await con.QueryFirstOrDefaultAsync<Reserva>(queryCommand, parameters, commandType: CommandType.StoredProcedure);
                return reserva;
            }
        }

        //-------------------Post------------------------------
        public async Task<string> PostReserva(Reserva reserva)
        {
            string queryCommand = "sp_InsertarReserva";
            var parameters = new DynamicParameters();
            parameters.Add("@idHuesped", reserva.id_huesped, DbType.Int32);
            parameters.Add("@idServicio", reserva.id_servicio, DbType.Int32);
            parameters.Add("@fechaReserva", reserva.fecha_reserva, DbType.String);
            parameters.Add("@fechaIngreso", reserva.fecha_ingreso, DbType.String);
            parameters.Add("@fechaSalida", reserva.fecha_salida, DbType.String);
            parameters.Add("@estadoReserva", reserva.estado, DbType.String);

            using (var con = new MySqlConnection(_connectionString))
            {
                await con.ExecuteAsync(queryCommand, parameters, commandType: CommandType.StoredProcedure);
            }

            return "Reserva registrada";
        }

        //-------------------Put------------------------------
        public async Task<bool> PutReserva(Reserva reserva)
        {
            string queryCommand = "sp_ActualizarReserva";
            var parameters = new DynamicParameters();
            parameters.Add("@idR", reserva.id_reserva, DbType.Int32);
            parameters.Add("@idHuesped", reserva.id_huesped, DbType.Int32);
            parameters.Add("@idServicio", reserva.id_servicio, DbType.Int32);
            parameters.Add("@fechaReserva", reserva.fecha_reserva, DbType.String);
            parameters.Add("@fechaIngreso", reserva.fecha_ingreso, DbType.String);
            parameters.Add("@fechaSalida", reserva.fecha_salida, DbType.String);
            parameters.Add("@estadoReserva", reserva.estado, DbType.String);

            using (var con = new MySqlConnection(_connectionString))
            {
                var result = await con.ExecuteAsync(queryCommand, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        //-------------------Delete------------------------------
        public async Task<bool> DeleteReserva(int id)
        {
            string queryCommand = "sp_EliminarReserva";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32);

            using (var con = new MySqlConnection(_connectionString))
            {
                var result = await con.ExecuteAsync(queryCommand, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
