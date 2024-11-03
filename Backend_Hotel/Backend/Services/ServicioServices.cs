using Dapper;
using Backend.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Backend.Services
{
    public class ServicioServices
    {

        private readonly IConfiguration _configuration;
        private readonly string _StringSql;

        public ServicioServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _StringSql = _configuration.GetConnectionString("MyDB")!;
        }

        // Configuración de los procedimientos almacenados
        public async Task<Servicio> GetServicio(int id)
        {
            string _queryCommand = "sp_ObtenerServicio";
            var parametro = new DynamicParameters();
            parametro.Add("@id", id, DbType.Int32);

            using (var con = new MySqlConnection(_StringSql))
            {
                var _servicio = await con.QueryFirstOrDefaultAsync<Servicio>(
                    _queryCommand, parametro, commandType: CommandType.StoredProcedure);
                return _servicio;
            } 


        }

        public async Task<string> PostServicio(Servicio Oservicio)
        {
            string queryCommand = "sp_InsertarServicio";
            var parametro = new DynamicParameters();

            parametro.Add("@Nom", Oservicio.nombre, dbType: DbType.String);
            parametro.Add("@Descrip", Oservicio.descripcion, dbType: DbType.String);
            parametro.Add("@Preci", Oservicio.precio, dbType: DbType.Int32);

            using (var con = new MySqlConnection(_StringSql))
            {
                await con.ExecuteAsync(queryCommand, parametro, commandType: CommandType.StoredProcedure);
            }

            return "Nueva servicio registrado";
        }

        public async Task<string> PutServicio(Servicio Oservicio)
        {
            string queryCommand = "sp_ActualizarServicio";
            var parametro = new DynamicParameters();

            parametro.Add("@id_s", Oservicio.id_servicio, dbType: DbType.Int32);
            parametro.Add("@Nom", Oservicio.nombre, dbType: DbType.String);
            parametro.Add("@Descrip", Oservicio.descripcion, dbType: DbType.String);
            parametro.Add("@Preci", Oservicio.precio, dbType: DbType.Int32);

            using (var con = new MySqlConnection(_StringSql))
            {
                await con.ExecuteAsync(queryCommand, parametro, commandType: CommandType.StoredProcedure);
            }

            return "Servicio actualizado";
        }

        public async Task<string> DeleteServicio(int id)
        {
            string queryCommand = "sp_EliminarServicio";
            var parametro = new DynamicParameters();
            parametro.Add("@id_s", id, dbType: DbType.Int32);

            using (var con = new MySqlConnection(_StringSql))
            {
                await con.ExecuteAsync(queryCommand, parametro, commandType: CommandType.StoredProcedure);

            }
            return "Servicio Eliminada";

        }
    }
}
