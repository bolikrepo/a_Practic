using System;
using System.Data;

namespace DatabaseStore
{
    public abstract class DatabaseAdapterPairBase<TConnection, TAdapter>
        where TAdapter : IDbDataAdapter
    {
        private readonly Lazy<TAdapter> _lAdapter = new Lazy<TAdapter>();

        public string TableName { get; private set; }
        public DataTable Table { get; private set; }
        public TAdapter TableAdapter { get; private set; }
        public TConnection Connection { get; private set; }

        public DatabaseAdapterPairBase(string tableName, TConnection connection, TAdapter adapter, DataTable table)
        {
            TableAdapter = adapter;
            Table = table;
            TableName = tableName;
            Connection = connection;
        }

        public abstract void Update();
        public abstract void Fill();
        public virtual void Clear()
        {
            try { 
                Table.Clear(); 
                Table.AcceptChanges();
            } catch { }
        }
    }
}
