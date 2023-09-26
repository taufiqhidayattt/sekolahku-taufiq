using Dapper;
using Nuna.Lib.DataAccessHelper;
using sekolahku_jude.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace sekolahku_jude.DataAkses
{
    public class NilaiSiswaDal
    {
        private string _connString;


        public NilaiSiswaDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(NilaiSiswa model)
        {
            //  QUERY
            const string sql = @"
                INSERT INTO NilaiSiswa(SiswaId, KelasId, MapelId, MapelName, Nilai)
                VALUES (@SiswaId, @KelasId, @MapelId, @MapelName, @Nilai)";

            //  PARAM
            var dp = new DynamicParameters();

            dp.AddParam("@SiswaId", model.SiswaId, System.Data.SqlDbType.VarChar);
            dp.AddParam("@KelasId", model.KelasId, System.Data.SqlDbType.VarChar);
            dp.AddParam("@MapelId", model.MapelId, System.Data.SqlDbType.VarChar);
            dp.AddParam("@MapelName", model.MapelName, System.Data.SqlDbType.VarChar);
            dp.AddParam("@Nilai", model.Nilai, System.Data.SqlDbType.VarChar);

            //  EXECUTE
            using (var conn = new SqlConnection(_connString))
            {
                conn.Execute(sql, dp);
            }
        }

        public void Delete(string KelasId, string SiswaId)
        {
            //  QUERY
            const string sql = @"
                DELETE FROM
                    NilaiSiswa
                WHERE
                    KelasId = @KelasId 
                    AND SiswaId = @SiswaId ";

            //  PARAM
            var dp = new DynamicParameters(); 

            dp.AddParam("@KelasId", KelasId, System.Data.SqlDbType.VarChar);
            dp.AddParam("@SiswaId", SiswaId, System.Data.SqlDbType.VarChar);

            //  EXECUTE
            using (var conn = new SqlConnection(_connString))
            {
                conn.Execute(sql, dp);
            }
        }

        public IEnumerable<NilaiSiswa> ListData(string KelasId, string SiswaId)
        {
            //  QUERY
            const string sql = @"
                SELECT  
                    aa.SiswaId, aa.KelasId, aa.MapelId, aa.MapelName, aa.Nilai,
                    ISNULL(cc.KelasName, '') KelasName,                  
                    ISNULL(cc.MapelName, '') MapelName,                    
                    ISNULL(bb.SiswaName, '') SiswaName,

                FROM    
                    Jadwal aa
                    LEFT JOIN KelasId bb ON aa.KelasId = bb.KelasId
                    LEFT JOIN Mapel cc ON aa.MapelId = cc.MapelId 
                    LEFT JOIN Siswa cc ON aa.SiswaId = cc.SiswaId 

                WHERE
                    aa.KelasId = @KelasId 
                    AND aa.SiswaId = @SiswaId ";

            var dp = new DynamicParameters();
            dp.AddParam("KelasId", SiswaId, System.Data.SqlDbType.VarChar);
            dp.AddParam("SiswaId", KelasId, System.Data.SqlDbType.VarChar);


            //  EXECUTE
            using (var conn = new SqlConnection(_connString))
            {
                return conn.Read<NilaiSiswa>(sql, dp);
            }
        }
    }
}
