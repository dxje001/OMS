using OMS.Classes;
using OMS.ConnectionPool;
using OMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.DAO.Impl
{
    public class KvarDaoImpl : IKvarDao
    {
        public IEnumerable<Kvar> FindAll()
        {
            string query = "select id, KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara from kvar";
            List<Kvar> kvarList = new List<Kvar>();

    
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kvar kvar = new Kvar(reader.GetInt32(0), reader.GetString(1),
                                reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                            kvarList.Add(kvar);
                        }
                    }
                }
            }

            return kvarList;
        }

        public IEnumerable<Kvar> FindAllByDate()
        {
            string query = "select id, KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara from kvar where VremeKreiranja between :vremeKreiranja1 and :vremekreiranja2";
            List<Kvar> kvarList = new List<Kvar>();
            
            Console.WriteLine("Unos prvog datuma (yyyyMMddhhmmss): ");
            DateTime vreme1 =Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Unos drugog datuma (yyyyMMddhhmmss): ");
            DateTime vreme2 = Convert.ToDateTime(Console.ReadLine());

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vremeKreiranja1", DbType.DateTime);
                    ParameterUtil.AddParameter(command, "vremeKreiranja2", DbType.DateTime);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "vremeKreiranja1", vreme1);
                    ParameterUtil.SetParameterValue(command, "vremeKreiranja1", vreme2);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kvar kvar = new Kvar(reader.GetInt32(0), reader.GetString(1),
                                reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                            kvarList.Add(kvar);
                        }
                    }
                }
            }

            return kvarList;
        }

        public Kvar FindById(string idKvara)
        {
            string query = "select id, KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara from kvar where IdKvara = :IdKvara";
            Kvar kvar = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "IdKvara", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "IdKvara", idKvara);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            kvar = new Kvar(reader.GetInt32(0), reader.GetString(1),
                               reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                            
                        }
                    }
                }
            }

            return kvar;
        }

        public int Save(Kvar entity)
        {
            throw new NotImplementedException();
        }
    }
}
