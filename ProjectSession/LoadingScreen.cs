using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSession
{
    public partial class LoadingScreen : Form
    {
        private byte loadingOpacity = 255;
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            PrivateFontCollection modernFont = new PrivateFontCollection();

            modernFont.AddFontFile("./Fonts/BebasNeue Regular.otf");
            modernFont.AddFontFile("./Fonts/Roboto-Regular.ttf");

            label1.Font = new Font(modernFont.Families[1], 15);
            label2.Font = new Font(modernFont.Families[1], 15);
            label3.Font = new Font(modernFont.Families[1], 25);
            tip_label.Font = new Font(modernFont.Families[0], 20);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();

            this.Hide();

            new MainForm().ShowDialog();

            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
