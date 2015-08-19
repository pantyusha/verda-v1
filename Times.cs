using System;
using System.Collections.Generic;
using System.Text;

namespace Verda
{
    public static class Times
    {
        public static string TimeReport()
        {
            return DateTime.Now.ToString("[HH:mm:ss] ");
        }
        public static string DateFolderName()
        {
            return DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss-f");
        }
    }
}
