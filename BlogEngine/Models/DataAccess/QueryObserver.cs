using System.Data.SQLite;

namespace BlogEngine.Models.DataAccess
{
    public class QueryObserver
    {
        #region "Singleton implementation"
        private static QueryObserver _observer;

        private QueryObserver()
        {
        }

        public static QueryObserver Observer
        {
            get { return _observer ?? (_observer = new QueryObserver()); }
        }
        #endregion

        #region "Sql events"
        public delegate void DatabaseAccessDelegate(SQLiteCommand cmd);
        public event DatabaseAccessDelegate DatabaseAccessEvent;

        public void RaiseDatabaseAccessEvent(SQLiteCommand cmd)
        {
            if (DatabaseAccessEvent != null)
                DatabaseAccessEvent(cmd);
        }
        #endregion
    }
}