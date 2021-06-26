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

        private void button1_Click(object sender, EventArgs e)
        {
            formSwitcher.switchForm(new Form1(DatabasePresenter.PersonSet));
            label1.Text = "Общий список людей агенства";

            if (lastButton != null)
            {
                lastButton.BackColor = Color.FromArgb(112, 111, +211);
            }

            button1.BackColor = Color.FromArgb(52, 172, 224);

            lastButton = (Button)sender;

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
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

            formSwitcher.switchForm(new Form1(DatabasePresenter.PersonSet_Client));

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

            formSwitcher.switchForm(new Form1(DatabasePresenter.PersonSet_Agent));

            label1.Text = "Список риэлторов агенства";
        }
    }
}
