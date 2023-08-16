using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam2usb.Models
{
    public class AUSB
    {
        public int UID { get; set; }
        public string UIC { get; set; }

        public AUSB(int d, string c)
        {
            this.UID = d;
            this.UIC = c;
        }
    }
}
