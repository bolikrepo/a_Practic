using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseStore;
using ProjectSession.Core;
using ProjectSession.DatabaseObjects;

namespace ProjectSession
{
    public partial class Form1 : Form
    {
        private FontManager f_manager = FontManager.GetInstance();

        DatabaseAdapterPair source = null;

        private string rowName = null; 
        
        public Form1(DatabaseAdapterPair p, string specificRowName)
        {
            InitializeComponent();

            this.source = p;
            this.rowName = specificRowName;

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

            dataGridView1.DataSource = source.Table;
            source.Fill();

            if (this.rowName != null)
            {
                dataGridView1.Columns.Remove(rowName);

                var records = new DatabaseReader("Data Source=\"192.168.102.242, 1433\";Initial Catalog=RealEstateAgency;Persist Security Info=True;User ID=ADM;Password=Samsung123").SqlQuery<Client>("select * from Clients_Name_ID");

                DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();

                foreach (Client client in records)
                {
                    dgvCmb.HeaderText = "Agent";
                    dgvCmb.Items.Add(client.FirstName + " "+client.MiddleName) ;
                }
                dataGridView1.Columns.Add(dgvCmb);
            }
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
                MessageManager.showError("Ошибка обновления данных", err.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                DataTable dt = SearchInAllColums(source.Table, textBox1.Text, StringComparison.OrdinalIgnoreCase);
                dataGridView1.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        { 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }
    }
}
