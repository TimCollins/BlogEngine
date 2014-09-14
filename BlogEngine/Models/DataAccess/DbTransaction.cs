using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace BlogEngine.Models.DataAccess
{
    public class DbTransaction : IDisposable
    {
        private const string ConnectionStringName = "SQLiteConnectionString";

        [ThreadStatic]
        internal static DbTransaction CurrentTransaction;

        private readonly SQLiteTransaction _transaction;
        private bool _complete;

        public DbTransaction()
        {
            if (CurrentTransaction != null)
                throw new ApplicationException("There is another transaction active on this thread!");

            SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
            conn.Open();
            _transaction = conn.BeginTransaction();

            CurrentTransaction = this;
        }

        public void Commit()
        {
            if (_complete)
                throw new ApplicationException("This transaction has already completed!");

            SQLiteConnection conn = _transaction.Connection;
            _transaction.Commit();
            Cleanup(conn);
        }

        public void Rollback()
        {
            if (_complete)
                throw new ApplicationException("This transaction has already completed!");

            SQLiteConnection conn = _transaction.Connection;

            _transaction.Rollback();

            Cleanup(conn);
        }

        public void Dispose()
        {
            if (!_complete)
                Rollback();
        }

        private void Cleanup(SQLiteConnection conn)
        {
            CurrentTransaction = null;

            conn.Close();
            conn.Dispose();

            _complete = true;
        }

        internal class CommandContext : IDisposable
        {
            internal SQLiteCommand Command { get; private set; }
            private SQLiteConnection Connection { get; set; }

            internal CommandContext()
            {
                if (CurrentTransaction == null)
                {
                    ConfigManager config = new ConfigManager();

                    Connection = new SQLiteConnection(config.GetConnectionString(ConnectionStringName));
                    //Connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
                    Connection.Open();
                    Command = Connection.CreateCommand();
                }
                else
                {
                    Connection = CurrentTransaction._transaction.Connection;
                    Command = Connection.CreateCommand();
                    Command.Transaction = CurrentTransaction._transaction;
                }
            }

            public virtual void Dispose()
            {
                Command.Dispose();

                if (CurrentTransaction == null)
                    Connection.Close();
            }
        }

        internal class ReaderContext : CommandContext
        {
            internal CommandBehavior Behavior
            {
                get
                {
                    return CurrentTransaction == null ? CommandBehavior.CloseConnection : CommandBehavior.Default;
                }
            }

            public override void Dispose()
            {
            }
        }
    }
}