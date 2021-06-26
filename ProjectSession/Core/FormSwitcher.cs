using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectSession.Core
{
    public class FormSwitcher
    {
        private Panel renderPanel = null;
        private Form lastForm = null;

        public FormSwitcher(Panel viewer)
        {
            this.renderPanel = viewer;
        }

        private bool switchFormOpacityTo(Form target, double opacity, double speed)
        {
            if (target.Opacity > opacity)
            {
                while (target.Opacity != opacity)
                {
                    opacity -= speed; // this can be changed
                }
            }
            else if (target.Opacity < opacity)
            {
                while (target.Opacity != opacity)
                {
                    opacity += speed; // this can be changed
                }
            }

            return true;
        }

        private bool switchFormOpacityTo(Form target, float startWith, double endWith, double speed)
        {
            if (startWith > endWith)
            {
                if (speed <= 0.99)
                {
                    while (startWith != endWith)
                    {
                        target.Opacity += speed; // this can be changed
                    }
                }
                else
                {
                    target.Opacity = endWith; // this can be changed
                }
            }
            else if (startWith < endWith)
            {
                if (speed <= 0.99)
                {
                    while (startWith != endWith)
                    {
                        target.Opacity -= speed; // this can be changed
                    }
                }
                else
                {
                    target.Opacity = endWith; // this can be changed
                }
            }

            return true;
        }

        public void switchForm(Form form)
        {
            if (form != null)
            {
                for (int i = 0; i < 15; i++)
                {
                    try
                    {
                        if (lastForm != null)
                        {
                            lastForm.Close();
                        }
                        lastForm = form;
                        form.TopLevel = false;

                        form.FormBorderStyle = FormBorderStyle.None;
                        form.Dock = DockStyle.Fill;

                        renderPanel.Controls.Add(form);
                        renderPanel.Tag = form;

                        form.BringToFront();
                        form.Show();

                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }
    }
}
