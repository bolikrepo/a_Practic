using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace DatabaseStore
{
    public class SqlCommandGenerator
    {
        public SqlConnection Connection { get; private set; }
        public string TableName { get; private set; }
        public IReadOnlyList<string> Columns { get; private set; }

        public SqlCommandGenerator(string tableName, SqlDataAdapter adapter, SqlConnection connection)
        {
            this.Connection = connection;
            this.TableName = tableName;
            ExecuteHelp(() =>
            {
                this.Columns = ExtractColumns(tableName, connection);
            });

            if (adapter.SelectCommand == null)
            {
                adapter.SelectCommand = GenerateSelectCommand();
            }

            if (adapter.InsertCommand == null)
            {
                adapter.InsertCommand = GenerateInsertCommand();
            }

            if (adapter.UpdateCommand == null)
            {
                adapter.UpdateCommand = GenerateUpdateCommand();
            }

            if (adapter.DeleteCommand == null)
            {
                adapter.DeleteCommand = GenerateDeleteCommand();
            }

        }

        #region HELP OPERATIONS

        private void ExecuteHelp(Action exec)
        {
            Connection.Open();
            exec.Invoke();
            Connection.Close();
        }

        private static List<string> ExtractColumns(string tableName, SqlConnection connection)
        {
            List<string> columns = new List<string>();
            IDataReader reader = new SqlCommand(
                $"SELECT COLUMN_NAME FROM information_schema.columns WHERE table_name = '{tableName}'", connection).ExecuteReader();

            while (reader.Read()) columns.Add(reader.GetValue(0).ToString());
            return columns;
        }

        #endregion

        private SqlCommand GenerateSelectCommand()
        {
            SqlCommand cmd = new SqlCommand { Connection = Connection };

            string columnsText = Columns.Aggregate((a, b) => $"{a}, {b}");

            string cmdText = $"SELECT {columnsText} FROM {TableName}";

            cmd.CommandText = cmdText;
            return cmd;
        }

        private SqlCommand GenerateInsertCommand()
        {
            SqlCommand cmd = new SqlCommand { Connection = Connection };

            string columnsText = Columns.Aggregate((a,b) => $"{a}, {b}");
            string columnsParamText = "@"+Columns.Aggregate(
            (a, b) => $"{a}, @{b.Replace(' ', '_')}");

            string cmdText = $"INSERT INTO {TableName} ({columnsText}) VALUES ({columnsParamText})";

            foreach (var col in Columns) cmd.Parameters.Add(new SqlParameter($"@{col.Replace(' ', '_')}", SqlDbType.VarChar, 0, col));

            cmd.CommandText = cmdText;
            return cmd;
        }

        private SqlCommand GenerateUpdateCommand()
        {
            SqlCommand cmd = new SqlCommand { Connection = Connection };

            int index;
            index = 0;
            string columnsText = Columns.Aggregate(
                (a, b) => 
                {
                    if (index == 0) a += $" = @{a.Replace(' ', '_')}";
                    index++;
                    return $"{a}, {b} = @{b.Replace(' ', '_')}";
                }
            );
            index = 0;
            string whereText = Columns.Aggregate(
                (a, b) =>
                {
                    if (index == 0) a += $" = @OLD_{a.Replace(' ', '_')}";
                    index++;
                    return $"{a} AND {b} = @OLD_{b.Replace(' ', '_')}";
                }
            );

            string cmdText = $"UPDATE {TableName} SET {columnsText} WHERE {whereText}";

            foreach (string col in Columns)
            {
                string cl = col.Replace(' ', '_');

                cmd.Parameters.Add(
                    new SqlParameter($"@{cl}", SqlDbType.VarChar, 0, col)
                );

                cmd.Parameters.Add(
                    new SqlParameter($"@OLD_{cl}", SqlDbType.VarChar, 0, col) { SourceVersion = DataRowVersion.Original }
                );
            }

            cmd.CommandText = cmdText;

            return cmd;
        }

        private SqlCommand GenerateDeleteCommand()
        {
            SqlCommand cmd = new SqlCommand { Connection = Connection };


            int index = 0;
            string whereText = Columns.Aggregate(
                (a, b) =>
                {
                    if (index == 0) a += $" = @OLD_{a.Replace(' ', '_')}";
                    index++;
                    return $"{a} AND {b} = @OLD_{b.Replace(' ', '_')}";
                }
            );

            string cmdText = $"DELETE FROM {TableName} WHERE {whereText}";
            

            foreach (string col in Columns)
            {
                string cl = col.Replace(' ', '_');

                cmd.Parameters.Add(
                    new SqlParameter($"@OLD_{cl}", SqlDbType.VarChar, 0, col) { SourceVersion = DataRowVersion.Original }
                );
            }

            cmd.CommandText = cmdText;
            return cmd;
        }

        /*
        private SqlCommand generateInsertCommand(IReadOnlyList<string> columns)
        {
            SqlCommand cmd;
            string cmdText;

            string intoText = "";
            string valuesText = "";

            cmdText = $"INSERT INTO {TableName}";
            cmd = new SqlCommand("", Connection);

            for (int i = -1; i++ < columns.Count - 1;)
            {
                string column = columns[i];

                string sep = (i != columns.Count - 1) ? ", " : "";
                intoText += $"[{column}]" + sep;
                valuesText += $"@{column}".Replace(' ', '_') + sep;

                cmd.Parameters.Add(
                    new SqlParameter($"@{column}", SqlDbType.VarChar, 0, column)
                );
            }
            cmdText = $"{cmdText} ({intoText}) VALUES ({valuesText})";

            cmd.CommandText = cmdText;
            return cmd;
        }
        */

        /*
        private SqlCommand generateUpdateCommand(List<string> columns)
        {
            SqlCommand cmd;
            string cmdText;
            string primaryKey;

            cmdText = $"UPDATE {TableName} SET ";
            cmd = new SqlCommand("", Connection);

            primaryKey = "old";
            for (int i = -1; i++ < columns.Count - 1;)
            {
                string column = columns[i];

                if (i == 0)
                {
                    primaryKey = $"@old{column}";
                    var param = new SqlParameter(primaryKey, SqlDbType.VarChar, 0, column);
                    param.SourceVersion = DataRowVersion.Original;
                    cmd.Parameters.Add(param);
                    primaryKey = $"{column}={primaryKey}";
                }
                cmdText += $"{column}=@{column}";
                cmdText += (i != columns.Count - 1) ? ", " : " ";

                cmd.Parameters.Add($"@{column}", SqlDbType.VarChar, 300, column);
            }
            cmdText += $"WHERE {primaryKey}";

            cmd.CommandText = cmdText;
            return cmd;
        }
        /*
        private SqlCommand generateDeleteCommand(List<string> columns)
        {
            string column = columns[0];
            SqlCommand cmd = new SqlCommand($"DELETE FROM {table} WHERE {column}=@{column}", connection);
            cmd.Parameters.Add($"@{column}", MySqlDbType.VarChar, 300, column).SourceVersion = DataRowVersion.Original;
            return cmd;
        }

        */
    }
}
