using Dapper;
using Nuna.Lib.DataAccessHelper;
using sekolahku_jude.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sekolahku_jude.DataAkses
{
    public class SiswaDal
    {
        private string _connString;
        public SiswaDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(SiswaModel model)
        {
            //  QUERY
            const string sql = @"
                INSERT INTO Siswa(SiswaId, SiswaName, TglLahir, Alamat, Alamat2, Kota)
                VALUES (@SiswaId, @SiswaName, @TglLahir, @Alamat, @Alamat2, @Kota)";

            //  PARAM
            var dp = new DynamicParameters();
            dp.AddParam("@SiswaId", model.SiswaId, System.Data.SqlDbType.VarChar);
            dp.AddParam("@SiswaName", model.SiswaName, System.Data.SqlDbType.VarChar);
            dp.AddParam("@TglLahir", model.TglLahir, System.Data.SqlDbType.DateTime);
            dp.AddParam("@Alamat", model.Alamat, System.Data.SqlDbType.VarChar);
            dp.AddParam("@Alamat2", model.Alamat2, System.Data.SqlDbType.VarChar);
            dp.AddParam("@Kota", model.Kota, System.Data.SqlDbType.VarChar);
            //  EXECUTE
            using (var conn = new SqlConnection(_connString))
            {
                conn.Execute(sql, dp);
            }
        }

        public void Update(SiswaModel model)
        {
            //  QUERY
            const string sql = @"
                UPDATE
                    Siswa
                SET
                    SiswaName = @SiswaName
                    TglLahir = @TglLahir
                    Alamat = @Alamat
                    Alamat2 = @Alamat2
                    Kota = @Kota

                WHERE
                    SiswaId = @SiswaId ";

            //  PARAM
            var dp = new DynamicParameters();
            dp.AddParam("@SiswaId", model.SiswaId, System.Data.SqlDbType.VarChar);
            dp.AddParam("@SiswaName", model.SiswaName, System.Data.SqlDbType.VarChar);
            dp.AddParam("@TglLahir", model.TglLahir, System.Data.SqlDbType.DateTime);
            dp.AddParam("@Alamat", model.Alamat, System.Data.SqlDbType.VarChar);
            dp.AddParam("@Alamat2", model.Alamat2, System.Data.SqlDbType.VarChar);
            dp.AddParam("@Kota", model.Kota, System.Data.SqlDbType.VarChar);

            //  EXECUTE
            using (var conn = new SqlConnection(_connString))
            {
                conn.Execute(sql, dp);
            }
        }
        public void Delete(string siswaId)
        {
            //  QUERY
            const string sql = @"
                DELETE FROM
                    Siswa
                WHERE
                    SiswaId = @SiswaId ";

            //  PARAM
            var dp = new DynamicParameters();
            dp.AddParam("@SiswaId", siswaId, System.Data.SqlDbType.VarChar);

            //  EXECUTE
            using (var conn = new SqlConnection(_connString))
            {
                conn.Execute(sql, dp);
            }
        }
        public SiswaModel GetData(string siswaId)
        {
            //  QUERY
            const string sql = @"
                SELECT  SiswaId, SiswaName, TglLahir, Alamat, Alamat2, Kota
                FROM    Siswa
                WHERE   SiswaId = @SiswaId ";

            //  PARAM
            var dp = new DynamicParameters();
            dp.AddParam("@SiswaId", siswaId, System.Data.SqlDbType.VarChar);

            //  EXECUTE
            using (var conn = new SqlConnection(_connString))
            {
                return conn.ReadSingle<SiswaModel>(sql, dp);
            }
        }

        public IEnumerable<SiswaModel> ListData()
        {
            //  QUERY
            const string sql = @"
                SELECT  SiswaId, SiswaName, TglLahir, Alamat, Alamat2, Kota
                FROM    Siswa ";

            //  EXECUTE
            using (var conn = new SqlConnection(_connString))
            {
                return conn.Read<SiswaModel>(sql);
            }
        }
    }
}
