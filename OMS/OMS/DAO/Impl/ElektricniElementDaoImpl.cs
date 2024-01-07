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
    public class ElektricniElementDaoImpl : IElektricniElementDao
    {
        public int GetCount()
        {
            string query = "select count(*) from elemenat";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    
                    command.Prepare();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public ElektricniElement FindByID(string ide)
        {
            string query = "select * from elemenat where elementid = :elementid";
            ElektricniElement element = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "elementid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "elementid", ide);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            element = new ElektricniElement(reader.GetInt32(0), reader.GetString(1),
                               reader.GetString(2), reader.GetString(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetString(6));

                        }
                       
                    }
                }
            }
            return element;
        }

        public int Save(ElektricniElement entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(ElektricniElement entity, IDbConnection connection)
        {
            string insertSql = "insert into elemenat (ide, elementid, naziv, tip, geografskasirina, geografskaduzina, naponskinivo) " +
                "values (:ide, :elementid, :naziv, :tip, :geografskasirina, :geografskaduzina, :naponskinivo)";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = insertSql;
                ParameterUtil.AddParameter(command, "ide", DbType.Int64);
                ParameterUtil.AddParameter(command, "elementid", DbType.String);
                ParameterUtil.AddParameter(command, "naziv", DbType.String);
                ParameterUtil.AddParameter(command, "tip", DbType.String);
                ParameterUtil.AddParameter(command, "geografskasirina", DbType.Object);
                ParameterUtil.AddParameter(command, "geografskaduzina", DbType.AnsiString);
                ParameterUtil.AddParameter(command, "naponskinivo", DbType.String);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "ide", entity.Id);
                ParameterUtil.SetParameterValue(command, "elementid", entity.ElementId);
                ParameterUtil.SetParameterValue(command, "naziv", entity.Naziv);
                ParameterUtil.SetParameterValue(command, "tip", entity.Tip);
                ParameterUtil.SetParameterValue(command, "geografskasirina", entity.GeografskaSirina);
                ParameterUtil.SetParameterValue(command, "geografskaduzina", entity.GeografskaDuzina);
                ParameterUtil.SetParameterValue(command, "naponskinivo", entity.NaponskiNivo);

                return command.ExecuteNonQuery();
            }
        }

        
    }
}
