using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Globalization;

namespace DatabaseStore
{
    public class ColumnTypePair
    {
        public string Name { get; set; }
        public SqlDbType Type { get; set; }

        public override string ToString() => Name;
        public static implicit operator string(ColumnTypePair that) => that.ToString();
    }
    public class SqlCommandGenerator
    {
        public SqlConnection Connection { get; private set; }
        public string TableName { get; private set; }
        public IReadOnlyList<ColumnTypePair> Columns { get; private set; }

        private static SqlDbType type = SqlDbType.VarChar;
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

        private static SqlDbType ParseColumnType(string type)
        {
            try
            {
                return (SqlDbType)Enum.Parse(typeof(SqlDbType), type, true);
            }catch{ }
            return SqlDbType.VarChar;
        }

        private static List<ColumnTypePair> ExtractColumns(string tableName, SqlConnection connection)
        {
            List<ColumnTypePair> columns = new List<ColumnTypePair>();
            IDataReader reader = new SqlCommand(
                $"SELECT COLUMN_NAME, DATA_TYPE FROM information_schema.columns WHERE table_name = '{tableName}'", connection).ExecuteReader();

            while (reader.Read()) 
                columns.Add(
                    new ColumnTypePair { 
                        Name = reader.GetValue(0).ToString(), 
                        Type = ParseColumnType(reader.GetValue(1).ToString()) 
                    } 
                );
            return columns;
        }

        #endregion

        private SqlCommand GenerateSelectCommand()
        {
            SqlCommand cmd = new SqlCommand { Connection = Connection };
            var columns = from c in Columns select c.ToString();
            string columnsText = columns.Aggregate((a, b) => $"{a}, {b}");

            string cmdText = $"SELECT {columnsText} FROM {TableName}";

            cmd.CommandText = cmdText;
            return cmd;
        }

        private SqlCommand GenerateInsertCommand()
        {
            SqlCommand cmd = new SqlCommand { Connection = Connection };

            var columns = from c in Columns select c.ToString();
            string columnsText = columns.Aggregate((a,b) => $"{a}, {b}");
            string columnsParamText = "@"+columns.Aggregate(
            (a, b) => $"{a}, @{b.Replace(' ', '_')}");

            string cmdText = $"INSERT INTO {TableName} ({columnsText}) VALUES ({columnsParamText})";

            foreach (var col in Columns) 
                cmd.Parameters.Add(new SqlParameter($"@{col.ToString().Replace(' ', '_')}", col.Type, 0, col));

            cmd.CommandText = cmdText;
            return cmd;
        }

        private SqlCommand GenerateUpdateCommand()
        {
            SqlCommand cmd = new SqlCommand { Connection = Connection };

            var columns = from c in Columns select c.ToString();
            int index;
            index = 0;
            string columnsText = columns.Aggregate(
                (a, b) => 
                {
                    if (index == 0) a += $" = @{a.Replace(' ', '_')}";
                    index++;
                    return $"{a}, {b} = @{b.Replace(' ', '_')}";
                }
            );
            index = 0;
            string whereText = columns.Aggregate(
                (a, b) =>
                {
                    if (index == 0) a += $" = @OLD_{a.Replace(' ', '_')}";
                    index++;
                    return $"{a} AND {b} = @OLD_{b.Replace(' ', '_')}";
                }
            );

            string cmdText = $"UPDATE {TableName} SET {columnsText} WHERE {whereText}";

            foreach (var col in Columns)
            {
                string cl = col.ToString().Replace(' ', '_');

                cmd.Parameters.Add(
                    new SqlParameter($"@{cl}", col.Type, 0, col)
                );

                cmd.Parameters.Add(
                    new SqlParameter($"@OLD_{cl}", col.Type, 0, col) { SourceVersion = DataRowVersion.Original }
                );
            }

            cmd.CommandText = cmdText;

            return cmd;
        }

        private SqlCommand GenerateDeleteCommand()
        {
            SqlCommand cmd = new SqlCommand { Connection = Connection };

            var columns = from c in Columns select c.ToString();
            int index = 0;
            string whereText = columns.Aggregate(
                (a, b) =>
                {
                    if (index == 0) a += $" = @OLD_{a.Replace(' ', '_')}";
                    index++;
                    return $"{a} AND {b} = @OLD_{b.Replace(' ', '_')}";
                }
            );

            string cmdText = $"DELETE FROM {TableName} WHERE {whereText}";
            

            foreach (var col in Columns)
            {
                string cl = col.ToString().Replace(' ', '_');

                cmd.Parameters.Add(
                    new SqlParameter($"@OLD_{cl}", col.Type, 0, col) { SourceVersion = DataRowVersion.Original }
                );
            }

            cmd.CommandText = cmdText;
            return cmd;
        }

    }
}
