using Dapper;
using Backend.Models;
using MySql.Data.MySqlClient;
using System.Data;



namespace Backend.Services
{
    public class HabitacionServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public HabitacionServices(IConfiguration configuration) 
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;
        }

        // Configuración de los procedimientos almacenados
        public async Task<Habitacion> GetHabitacion(int id)
        {
            string _queryCommand = "sp_ObtenerHabitacion";
            var parametro = new DynamicParameters();
            parametro.Add("@id", id, DbType.Int32);

            using (var con = new MySqlConnection(_StringSql))
            {
                var _habitacion = await con.QueryFirstOrDefaultAsync<Habitacion>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _habitacion;
            }  // Corregido: Cierre de la llave faltante


        }

        public async Task<string> PostHabitacion(Habitacion Ohabitacion)
        {
            string queryCommand = "sp_InsertarHabitacion";
            var parametro = new DynamicParameters();

            parametro.Add("@Num", Ohabitacion.numero, dbType: DbType.String);
            parametro.Add("@Tip", Ohabitacion.tipo, dbType: DbType.String);
            parametro.Add("@Cap", Ohabitacion.capacidad, dbType: DbType.Int32);
            parametro.Add("@Preciob", Ohabitacion.precio_base, dbType: DbType.Int32);
            parametro.Add("@Estad", Ohabitacion.estado, dbType: DbType.String);

            using (var con = new MySqlConnection(_StringSql))
            {
                await con.ExecuteAsync(queryCommand, parametro, commandType: CommandType.StoredProcedure);
            }

            return "Nueva habitacion registrada";
        }

        public async Task<string> PutHabitacion(Habitacion Ohabitacion)
        {
            string queryCommand = "sp_ActualizarHabitacion";
            var parametro = new DynamicParameters();

            parametro.Add("@id", Ohabitacion.id_habitacion, dbType: DbType.Int32);
            parametro.Add("@Num", Ohabitacion.numero, dbType: DbType.String);
            parametro.Add("@Tip", Ohabitacion.tipo, dbType: DbType.String);
            parametro.Add("@Cap", Ohabitacion.capacidad, dbType: DbType.Int32);
            parametro.Add("@Preciob", Ohabitacion.precio_base, dbType: DbType.Int32);
            parametro.Add("@Estad", Ohabitacion.estado, dbType: DbType.String);

            using (var con = new MySqlConnection(_StringSql))
            {
                await con.ExecuteAsync(queryCommand, parametro, commandType: CommandType.StoredProcedure);
            }

            return "Habitacion actualizado";
        }

        public async Task<string> DeleteHabitacion(int id)
        {
            string queryCommand = "sp_EliminarHabitacion";
            var parametro = new DynamicParameters();
            parametro.Add("@id_h", id, dbType: DbType.Int32);

            using (var con = new MySqlConnection(_StringSql))
            {
                await con.ExecuteAsync(queryCommand, parametro, commandType: CommandType.StoredProcedure);
                
            }
            return "Habitacion Eliminada";

        }
    }
}
