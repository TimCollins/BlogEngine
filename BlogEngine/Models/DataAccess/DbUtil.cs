using System.Data;
using System.Data.SQLite;

namespace BlogEngine.Models.DataAccess
{
    /// <summary>
    /// SQLite version of various low level data-access operations.
    /// </summary>
    public class DbUtil
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
    }
}