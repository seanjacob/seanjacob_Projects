using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase6
{

    public class Stig
    {

        public IDriveable WhatImDriving { get; set; }

        public Stig(IDriveable whatImDriving)
        {
            WhatImDriving = whatImDriving;
        }

        public void GoDriving(decimal amount)
        {
            WhatImDriving.Drive(amount);
        }
     
    }
}
