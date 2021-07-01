using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DatabaseStore;
using ProjectSession.Core;

namespace ProjectSession
{
    public partial class Form1 : Form
    {
        private FontManager f_manager = FontManager.GetInstance();

        DatabaseAdapterPair source = null;
        DataTable tempStorage { get; set; } = null;

        private List<FkDefinion> FkDefinions { get; } = new List<FkDefinion>();
        
        public Form1()
        {
            InitializeComponent();


            label1.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.TEXT), 15);
            textBox1.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.TEXT), 15);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.DefaultCellStyle.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.MENU), 15);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.MENU), 13);

        }

        public Form1(DatabaseAdapterPair p)
        {
            InitializeComponent();

            this.source = p;

            label1.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.TEXT), 15);
            textBox1.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.TEXT), 15);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.DefaultCellStyle.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.MENU), 15);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.MENU), 13);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            tempStorage = source.Table;
            dataGridView1.DataSource = tempStorage;
            source.Fill();
            EnsureFKs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();
                source.Update();
                MessageManager.showInfo("Обновление данных", "Данные успешно обновлены");
            }
            catch (Exception err)
            {
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                DataTable dt = SearchInAllColums(source.Table, textBox1.Text, StringComparison.OrdinalIgnoreCase);
                tempStorage = dt;
                dataGridView1.DataSource = tempStorage;
                EnsureFKs();
            }
        }

        public static DataTable SearchInAllColums(DataTable table, string keyword, StringComparison comparison)
        {

            if (keyword.Equals(""))
            {
                return table;
            }
            
            keyword = keyword.ToLower();
            
            DataRow[] filteredRows = table.Rows
                   .Cast<DataRow>()
                   .Where((row) => {

                       bool allow = false;

                       foreach (object i in row.ItemArray)
                       {
                           string item = i.ToString().ToLower();
                           if (item.IsInLevDistanceOf(keyword, 3))
                           {
                               allow = true;
                               break;
                           }
                       }
                       return allow;
                   }
                ).ToArray();

            if (filteredRows.Length == 0)
            {
                DataTable dtTemp = table.Clone();
                dtTemp.Clear();
                return dtTemp;
            }
            else
            {
                return filteredRows.CopyToDataTable();
            }
        }


        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        public void EnsureFKs()
        {
            try
            {
                if (FkDefinions.Count != 0)
                {
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        var defs = (from d in FkDefinions 
                            where (d.TargetColumn.ToLower() == col.Name.ToLower()) select d);
                        
                        foreach (var def in defs)
                        {
                            InsertForeignKey(def, col); 
                        }

                    }
                }
            }
            catch { EnsureFKs(); }
        }

        private void InsertForeignKey(FkDefinion def, DataGridViewColumn target)
        {
            try
            {
                def.Source.Fill();
                DataGridViewColumnCollection parent = dataGridView1.Columns;
                int index = parent.IndexOf(target);
                //parent[parent.IndexOf(col)] = GenerateFKColumn(def);
                parent.RemoveAt(index);
                var col = GenerateFKColumn(def);
                parent.Insert(index, col);
            }
            catch { InsertForeignKey(def, target); }
        }

        private DataGridViewColumn GenerateFKColumn(FkDefinion def)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            column.HeaderText = def.TargetColumn+"_FK";
            column.DataPropertyName = def.TargetColumn;

            column.DataSource = def.Source.Table;
            column.DisplayMember = def.PreviewDisplayColumn;
            column.ValueMember = def.PreviewOutputColumn;

            return column;
        }

        public static Builder New() => new Builder();
        public static Builder New(DatabaseAdapterPair source) => new Builder(source);
        public class Builder
        {
            private readonly Form1 instance;
            public Builder() { instance = new Form1(); }
            public Builder(DatabaseAdapterPair source) 
                { instance = new Form1(source); }

            public Builder Source(DatabaseAdapterPair value)
            {
                instance.source = value;
                return this;
            }

            public Builder DefineForeignKey(FkDefinion value)
            {
                instance.FkDefinions.Add(value);
                return this;
            }

            public Form1 build() => instance;
        }

    }
}
