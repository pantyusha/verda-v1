using System;
using System.Collections.Generic;
using System.Text;

namespace Verda
{
    public class Preset
    {
        private string myShortName;
        private string myDisplayName;

        public Preset(string strDisplayName, string strShortName)
        {

            this.myShortName = strShortName;
            this.myDisplayName = strDisplayName;
        }

        public string ShortName
        {
            get
            {
                return myShortName;
            }
        }

        public string DisplayName
        {

            get
            {
                return myDisplayName;
            }
        }
    }
}
