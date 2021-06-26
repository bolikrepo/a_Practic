using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSession.Core
{
    public class FontManager
    {
        private static FontManager _instance;

        private static PrivateFontCollection modernFont = new PrivateFontCollection();

        public enum FONT_TYPE
        {
            MENU, TEXT
        };

        public static FontManager GetInstance()
        {
            if (_instance == null)
            {

                modernFont.AddFontFile("./Fonts/BebasNeue Regular.otf");
                modernFont.AddFontFile("./Fonts/Roboto-Regular.ttf");

                _instance = new FontManager();
            }
            return _instance;
        }

        public FontFamily getFont(FONT_TYPE fType)
        {
            switch (fType)
            {
                case FONT_TYPE.MENU:
                    return modernFont.Families[1];
                case FONT_TYPE.TEXT:
                    return modernFont.Families[0];
            }

            return null;
        }


        private FontManager() { }

    }
}
