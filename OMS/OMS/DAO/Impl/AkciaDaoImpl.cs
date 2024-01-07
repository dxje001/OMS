using OMS.Classes;
using OMS.ConnectionPool;
using OMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace OMS.DAO.Impl
{
    public class AkciaDaoImpl : IAkcijaDao
    {
        public List<Akcija> GetAll(string kvarid)
        {
            string query = "select * " +
            "from akcija " +
                "where kvarid = :kvarid";
            List<Akcija> sceneList = new List<Akcija>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "kvarid", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "kvarid", kvarid);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Akcija scene = new Akcija(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3));
                            sceneList.Add(scene);
                        }
                    }
                }
            }

            return sceneList;
        }

        public int GetCount(string kvarid)
        {
            string query = "select count(*) from akcija where kvarid = :kvarid";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "kvarid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "kvarid", kvarid);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

      
    }
}
