using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace Verda
{
    public class NmapReceiver
    {
        public void OnReceive(string _received)
        {
            Program.NmapPost(_received);
        }
    }
}
