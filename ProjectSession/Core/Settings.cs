using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSession.Core
{
    public class Settings
    {
        public enum programVersion
        {
            FREE, VIP
        }
        
        public programVersion version { get; set; }
    }
}
