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
            string query = "select * from kvar";
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
            string query = "select idk, KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara from kvar where VremeKreiranja between ':vremeKreiranja1' and ':vremekreiranja2'";
            List<Kvar> kvarList = new List<Kvar>();
            
            Console.WriteLine("Unos prvog datuma (DD-MM-YY): ");
            DateTime vreme1 =Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Unos drugog datuma (DD-MM-YY): ");
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

        public Kvar FindById(int idKvara)
        {
            string query = "select idk, KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara from kvar where idk = :kvarid";
            Kvar kvar = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "kvarid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "kvarid", idKvara);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            kvar = new Kvar(reader.GetInt32(0), reader.GetString(1),
                               reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                            
                        }
                        else
                        {
                            Console.WriteLine("Ne postoji kvar sa id: " + idKvara);
                        }
                    }
                }
            }

            return kvar;
        }

        public int GetCount(string date)
        {

            string query = "select count(*) from kvar where kvarid like ':date' || '%'";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "date", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "date", date);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /*public bool ExistsById(string kvarid)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(idk, connection);
            }
        }
        */
        // connection is a parameter because this method is used in a transaction (see
        // saveAll method)
        /*
         * private bool ExistsById(string kvarid, IDbConnection connection)
         {
             string query = "select * from kvar where kvarid=:kvarid";

             using (IDbCommand command = connection.CreateCommand())
             {
                 command.CommandText = query;
                 ParameterUtil.AddParameter(command, "kvarid", DbType.Int32);
                 command.Prepare();
                 ParameterUtil.SetParameterValue(command, "kvarid", id);
                 return command.ExecuteScalar() != null;
             }
         }
        */

        public int Save(Kvar entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(Kvar entity, IDbConnection connection)
        {
            string insertSql = "insert into kvar ( kvarid, vremekreiranja, status, kratakopis, elektricnielement, opiskvara) " +
                "values (:kvarid, :vremekreiranja, :status, :kratakopis, :elektricnielement, :opiskvara)";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = insertSql;
                ParameterUtil.AddParameter(command, "kvarid", DbType.String,20);
                ParameterUtil.AddParameter(command, "vremekreiranja", DbType.DateTime);
                ParameterUtil.AddParameter(command, "status", DbType.String, 25);
                ParameterUtil.AddParameter(command, "kratakopis", DbType.String,1000);
                ParameterUtil.AddParameter(command, "elektricnielement", DbType.String,25);
                ParameterUtil.AddParameter(command, "opiskvara", DbType.String,1999);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "kvarid", entity.KvarId);
                ParameterUtil.SetParameterValue(command, "vremekreiranja", entity.VremeKreiranja);
                ParameterUtil.SetParameterValue(command, "status", entity.Status);
                ParameterUtil.SetParameterValue(command, "kratakopis", entity.KratakOpis);
                ParameterUtil.SetParameterValue(command, "elektricnielement", entity.ElektricniElement);             
                ParameterUtil.SetParameterValue(command, "opiskvara", entity.OpisKvara);

                return command.ExecuteNonQuery();
            }
        }

        public int Update(Kvar entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Update(entity, connection);
            }
        }

        private int Update(Kvar entity, IDbConnection connection)
        {
            string updateSql = "update kvar set status = :status, kratakopis = :kratakopis,  opiskvara=:opiskvara " +
                "where kvarid = :kvarid";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = updateSql;
                ParameterUtil.AddParameter(command, "kvarid", DbType.String, 25);

                ParameterUtil.AddParameter(command, "status", DbType.String, 25);
                ParameterUtil.AddParameter(command, "kratakopis", DbType.String, 1000);
                ParameterUtil.AddParameter(command, "opiskvara", DbType.String, 1999);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "kvarid", entity.KvarId);

                ParameterUtil.SetParameterValue(command, "status", entity.Status);
                ParameterUtil.SetParameterValue(command, "kratakopis", entity.KratakOpis);
                ParameterUtil.SetParameterValue(command, "opiskvara", entity.OpisKvara);

                return command.ExecuteNonQuery();
            }
        }
    }
}
