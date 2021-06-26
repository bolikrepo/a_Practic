﻿using System;
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
using ProjectSession.Core;


namespace ProjectSession
{
    public partial class Form1 : Form
    {
        private FontManager f_manager = FontManager.GetInstance();

        DatabaseAdapterPair pair = null;
        public Form1(DatabaseAdapterPair p)
        {
            InitializeComponent();

            this.pair = p;

            label1.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.TEXT), 15);
            textBox1.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.TEXT), 15);
            button1.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.TEXT), 15);

            this.dataGridView1.DefaultCellStyle.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.MENU), 15);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(f_manager.getFont(FontManager.FONT_TYPE.TEXT), 13);
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

            try
            {
                pair.Fill();

                dataGridView1.DataSource = pair.Database;
            }
            catch
            {

                pair.Fill();

                dataGridView1.DataSource = pair.Database;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pair.Update();
                MessageManager.showInfo("Обновление данных", "Данные успешно обновлены");
            }
            catch
            {
                MessageManager.showError("Произошла ошибка", "Для просмотра кода ошибки \n приобретите PRO-версию");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

                       foreach(object i in row.ItemArray)
                       {
                           string item = i.ToString().ToLower();
                           if(item.IsInLevDistanceOf(keyword, 3))
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
            DataTable dt = SearchInAllColums(pair.Database, textBox1.Text, StringComparison.OrdinalIgnoreCase);
            dataGridView1.DataSource = dt;
        }
    }
}