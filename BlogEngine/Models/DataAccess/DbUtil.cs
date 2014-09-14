using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace BlogEngine.Models.DataAccess
{
    /// <summary>
    /// SQLite version of various low level data-access operations.
    /// </summary>
    public static class DbUtil
    {
        public static SQLiteDataReader ExecuteReader(string sql, CommandType commandType, params SQLiteParameter[] parameters)
        {
            using (DbTransaction.ReaderContext context = new DbTransaction.ReaderContext())
            {
                SQLiteCommand cmd = context.Command;
                cmd.CommandType = commandType;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 0;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                QueryObserver.Observer.RaiseDatabaseAccessEvent(cmd);
                return cmd.ExecuteReader(context.Behavior);
            }
        }

        /// <summary>
        /// Overload of ExecuteReader which defaults the command type to Text.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] parameters)
        {
            return ExecuteReader(sql, CommandType.Text, parameters);
        }

        public static DataSet ExecuteDataSet(string sql, CommandType commandType, params SQLiteParameter[] parameters)
        {
            DataSet ds = new DataSet();

            using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["CML_Egghead"].ConnectionString))
            {
                conn.Open();

                SQLiteCommand cmd = conn.CreateCommand();

                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cmd.CommandTimeout = 0;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SQLiteDataAdapter adapter = new SQLiteDataAdapter { SelectCommand = cmd };

                QueryObserver.Observer.RaiseDatabaseAccessEvent(cmd);

                adapter.Fill(ds);

                adapter.Dispose();
                conn.Close();
            }

            return ds;
        }

        public static DataSet ExecuteDataSet(string sql, params SQLiteParameter[] parameters)
        {
            return ExecuteDataSet(sql, CommandType.Text, parameters);
        }

        public static object CheckNull<T>(T o)
        {
            if (o == null)
                return DBNull.Value;

            return o;
        }

        public static T Fetch<T>(this SQLiteDataReader rdr, string fname)
        {
            int ordinal = rdr.GetOrdinal(fname);

            if (rdr.IsDBNull(ordinal))
                return default(T);

            return (T)rdr[ordinal];
        }

        public static void AddWithValue(this List<SQLiteParameter> list, string name, object value)
        {
            list.Add(new SQLiteParameter(name, value));
        }

        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SQLiteParameter[] parameters)
        {
            int result;

            using (DbTransaction.CommandContext context = new DbTransaction.CommandContext())
            {
                SQLiteCommand cmd = context.Command;
                cmd.CommandType = cmdType;
                cmd.CommandTimeout = 0;
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);

                QueryObserver.Observer.RaiseDatabaseAccessEvent(cmd);

                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] parameters)
        {
            return ExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public static void ExecuteProcedure(string procedureName, params SQLiteParameter[] parameters)
        {
            using (DbTransaction.CommandContext context = new DbTransaction.CommandContext())
            {
                SQLiteCommand cmd = context.Command;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procedureName;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddRange(parameters);

                QueryObserver.Observer.RaiseDatabaseAccessEvent(cmd);

                cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] parameters)
        {
            object result;

            //using (SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["SQLiteConnectionString"].ConnectionString))
            using (SQLiteConnection conn = GetConnection())
            {
                conn.Open();

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 0;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                result = cmd.ExecuteScalar();

                conn.Close();
            }

            return result;
        }

        private static SQLiteConnection GetConnection()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SQLiteConnectionString"];
            if (settings == null)
            {
                throw new ConfigurationErrorsException("settings");
            }

            string conn = settings.ConnectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);

            return new SQLiteConnection(conn);
        }
    }
}