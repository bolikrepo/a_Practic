using DatabaseStore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            formSwitcher.switchForm(new Form1(DatatablesStore.Clients));

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

            formSwitcher.switchForm(new Form1(DatatablesStore.Agents));

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

            formSwitcher.switchForm(new Form1(DatatablesStore.Apartment));

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

            formSwitcher.switchForm(new Form1(DatatablesStore.House));

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

            formSwitcher.switchForm(new Form1(DatatablesStore.Land));

            label1.Text = "Список земельных участков";
        }
    }
}
