using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSession.Core
{
    class MessageManager
    {
        public static void showError(String title, String text)
        {
            MessageBox.Show(text, title,
    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void showInfo(String title, String text)
        {
            MessageBox.Show(text, title,
MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
