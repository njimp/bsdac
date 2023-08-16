using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sam2usb.Models
{
    public class AChannel
    {
        public int ChID { get; set; }
        public string ChDes { get; set; }

        public AChannel(int i)
        {
            this.ChID = i;
            this.ChDes = i.ToString();
            if (i == 0) this.ChDes += ": inner port";
        }
    }
}
