using ProjectSession.RealEstateAgencyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSession
{
    public abstract class DatabaseAdapterPairBase<TAdapter>
            where TAdapter : IDbDataAdapter
    {
        private readonly Lazy<TAdapter> _lAdapter = new Lazy<TAdapter>();

        public string TableName { get; private set; }
        public string TableJoinName { get; private set; }
        public DataTable Database { get; private set; }
        public TAdapter TableAdapter { get; private set; }

        public DatabaseAdapterPairBase(string tableName, string tableJoinName, TAdapter adapter, DataTable table)
        {
            TableAdapter = adapter;
            Database = table;
            TableName = tableName;
            TableJoinName = tableJoinName;
        }

        public abstract void Update();
        public abstract void Fill();
    }

    public class DatabaseAdapterPair : DatabaseAdapterPairBase<SqlDataAdapter>
    {
        public DatabaseAdapterPair(string tableName, string tableJoinName, SqlDataAdapter adapter, DataTable table)
            : base(tableName, tableJoinName, adapter, table) { }

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

            TableAdapter.Update(Database);
            
        }

        /// <summary>
        /// Adds or refreshes rows in a specified range in the System.Data.DataSet to match
        ///     those in the data source using the System.Data.DataTable name.
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        public override void Fill()
        {
            // не работет update, работаю над этим

            //if (TableAdapter != null)
            //{
            //    if (TableName != TableJoinName)
            //    {
            //        if (TableAdapter.SelectCommand == null)
            //        {
            //            TableAdapter.SelectCommand = new SqlCommand($"SELECT * FROM {TableName} LEFT JOIN {TableJoinName} ON {TableName}.Id = {TableJoinName}.ID", TableAdapter.UpdateCommand.Connection);
            //        }
            //    }
            //    else
            //    {
            //        if (TableAdapter.SelectCommand == null)
            //        {
            //            TableAdapter.SelectCommand = new SqlCommand($"SELECT * FROM {TableName}", TableAdapter.UpdateCommand.Connection);
            //        }
            //    }
            //    try
            //    {
            //        TableAdapter.Fill(Database);
            //    }
            //    catch
            //    {
            //        Core.MessageManager.showError("Ошибочка", "Кажется, произошла ошибка. А может и не произошла \n Попробуйте включить SQL-сервер.");
            //    }
            //}


            if (TableAdapter != null)
            {
                // select command - команда, которая будет вызываться при заполении таблицы
                if (TableAdapter.SelectCommand == null)
                {
                    TableAdapter.SelectCommand = new SqlCommand($"SELECT * FROM {TableName}", TableAdapter.UpdateCommand.Connection);
                }

                try
                {
                    TableAdapter.Fill(Database);
                }
                catch
                {
                    Core.MessageManager.showError("Ошибочка", "Кажется, произошла ошибка. А может и не произошла \n Попробуйте включить SQL-сервер.");
                }
            }
        }

    }


    public static class DatabasePresenter
    {
        public static RealEstateAgencyDataSet DataSet { get; } = new RealEstateAgencyDataSet();


        static DatabasePresenter()
        {

            PersonSet = new DatabaseAdapterPair
                ("PersonSet", "PersonSet", new PersonSetTableAdapter().Adapter, DataSet.PersonSet);

            PersonSet_Client = new DatabaseAdapterPair
    ("PersonSet_Client", "PersonSet", new PersonSet_ClientTableAdapter().Adapter, DataSet.PersonSet_Client);

            PersonSet_Agent = new DatabaseAdapterPair
("PersonSet_Agent", "PersonSet", new PersonSet_AgentTableAdapter().Adapter, DataSet.PersonSet_Agent);

        }

        // Datatable'ы базы, нужны для обновления и получения данных.

        // Для добавления новой таблицы - просто добавляешь новую точно такую же строку, но с названием свой таблицы
        public static DatabaseAdapterPair PersonSet { get; private set; }
        public static DatabaseAdapterPair PersonSet_Agent { get; private set; }
        public static DatabaseAdapterPair PersonSet_Client { get; private set; }
    }
}
