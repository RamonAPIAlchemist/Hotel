using System.Data;
using Backend.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Backend.Services
{
    public class HabitacionReservaServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public HabitacionReservaServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MyDB")!;
        }

        //-------------------Get------------------------------
        public async Task<HabitacionReserva> GetHabitacionReserva(int id)
        {
            string queryCommand = "sp_ObtenerHabitacionReserva";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32);

            using (var con = new MySqlConnection(_connectionString))
            {
                var habitacionReserva = await con.QueryFirstOrDefaultAsync<HabitacionReserva>(queryCommand, parameters, commandType: CommandType.StoredProcedure);
                return habitacionReserva;
            }
        }

        //-------------------Post------------------------------
        public async Task<string> PostHabitacionReserva(HabitacionReserva habitacionReserva)
        {
            string queryCommand = "sp_InsertarHabitacionReserva";
            var parameters = new DynamicParameters();
            parameters.Add("@idReserva", habitacionReserva.id_reserva, DbType.Int32);
            parameters.Add("@idHabitacion", habitacionReserva.id_habitacion, DbType.Int32);
            parameters.Add("@precioNoche", habitacionReserva.precio_noche, DbType.Int32);
            parameters.Add("@cantidadNoches", habitacionReserva.cantidad_noches, DbType.Int32);

            using (var con = new MySqlConnection(_connectionString))
            {
                await con.ExecuteAsync(queryCommand, parameters, commandType: CommandType.StoredProcedure);
            }

            return "Habitación de reserva registrada";
        }

        //-------------------Put------------------------------
        public async Task<bool> PutHabitacionReserva(HabitacionReserva habitacionReserva)
        {
            string queryCommand = "sp_ActualizarHabitacionReserva";
            var parameters = new DynamicParameters();
            parameters.Add("@idHabitacionReserva", habitacionReserva.id_habitacion_reserva, DbType.Int32);
            parameters.Add("@idReserva", habitacionReserva.id_reserva, DbType.Int32);
            parameters.Add("@idHabitacion", habitacionReserva.id_habitacion, DbType.Int32);
            parameters.Add("@precioNoche", habitacionReserva.precio_noche, DbType.Int32);
            parameters.Add("@cantidadNoches", habitacionReserva.cantidad_noches, DbType.Int32);

            using (var con = new MySqlConnection(_connectionString))
            {
                var result = await con.ExecuteAsync(queryCommand, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        //-------------------Delete------------------------------
        public async Task<bool> DeleteHabitacionReserva(int id)
        {
            string queryCommand = "sp_EliminarHabitacionReserva";
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
