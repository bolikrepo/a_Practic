using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseStore
{
    public class DatabaseAdapterPair : DatabaseAdapterPairBase<SqlConnection, SqlDataAdapter>
    {
        public DatabaseAdapterPair(string tableName, SqlConnection connection, SqlDataAdapter adapter, DataTable table)
            : base(tableName, connection, adapter, table)
        {
            new SqlCommandGenerator(tableName, adapter, connection);
        }


        #region INHERIT OPERATIONS

        /// <summary>
        ///     Updates the values in the database by executing the respective INSERT, UPDATE,
        ///     or DELETE statements for each inserted, updated, or deleted row in the specified
        ///     System.Data.DataTable.
        /// </summary>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="SystemException"/>
        /// <exception cref="DBConcurrencyException"/>
        public override void Update()
        {
            TableAdapter.Update(Table);
        }

        /// <summary>
        /// Adds or refreshes rows in a specified range in the System.Data.DataSet to match
        ///     those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        public override void Fill()
        {
            if (TableAdapter != null)
            {
                TableAdapter.Fill(Table);
            }
        }

        #endregion

    }
}
