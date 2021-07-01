using DatabaseStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectSession
{
    public partial class MainForm : Form
    {
        private Form currentForm = null;
        private Button lastButton = null;
        private Core.FormSwitcher formSwitcher = null;

        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;


            this.formSwitcher = new Core.FormSwitcher(childFormPanel);
        }

        private void updateButtonStyle(Button bt)
        {
            bt.TabStop = false;
            bt.FlatStyle = FlatStyle.Flat;
            bt.FlatAppearance.BorderSize = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            updateButtonStyle(button2);
            updateButtonStyle(button3);
            updateButtonStyle(apartments_button);
            updateButtonStyle(houses_button);
            updateButtonStyle(lands_button);
            updateButtonStyle(supplyset_button);
            updateButtonStyle(demand_set_button);
            updateButtonStyle(dealSet_button);
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            button2.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

            formSwitcher.switchForm(
                Form1.New(DataTablesStore.Clients).build()
            );

            label1.Text = "Список клиентов агенства";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            button3.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

            formSwitcher.switchForm(
                Form1.New(DataTablesStore.Agents).build()
            );

            label1.Text = "Список риэлторов агенства";
        }

        private void apartments_button_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            apartments_button.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

            formSwitcher.switchForm(
                Form1.New(DataTablesStore.Apartment).build()
            );

            label1.Text = "Список квартир";
        }

        private void houses_button_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            houses_button.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

            formSwitcher.switchForm(
                Form1.New(DataTablesStore.House).build()
            );

            label1.Text = "Список домов";
        }

        private void lands_button_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            lands_button.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

            formSwitcher.switchForm(
                Form1.New(DataTablesStore.Land).build()
            );

            label1.Text = "Список земельных участков";
        }

        private void supplyset_button_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            supplyset_button.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

            formSwitcher.switchForm(
                Form1.New()
                    .DefineForeignKey(new FkDefinion("AgentId", DataTablesStore.FK_Agents, ("ID", "Preview")))
                    .DefineForeignKey(new FkDefinion("ClientId", DataTablesStore.FK_Clients, ("ID", "Preview")))
                    .DefineForeignKey(new FkDefinion("RealEstateId", DataTablesStore.FK_RealEstate, ("ID", "Preview")))
                    .Source(DataTablesStore.Supplies)
                .build()
            );

            label1.Text = "Список предложений";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void demand_set_button_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            demand_set_button.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

            formSwitcher.switchForm(
                Form1.New()
                    .DefineForeignKey(new FkDefinion("AgentId", DataTablesStore.FK_Agents, ("ID", "Preview")))
                    .DefineForeignKey(new FkDefinion("ClientId", DataTablesStore.FK_Clients, ("ID", "Preview")))
                    .DefineForeignKey(new FkDefinion("RealEstateFilter_Id", DataTablesStore.FK_RealEstateFilter, ("ID", "ID")))
                    .Source(DataTablesStore.Demands)
                .build()
            );
        }

        private void dealSet_button_Click(object sender, EventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            dealSet_button.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

            formSwitcher.switchForm(
                Form1.New()
                    .DefineForeignKey(new FkDefinion("Demand_Id", DataTablesStore.Demands, ("Id", "Address_City")))
                    .DefineForeignKey(new FkDefinion("Supply_Id", DataTablesStore.Supplies, ("Id", "Id")))
                    .Source(DataTablesStore.Deals)
                .build()
            );
        }
    }
}
