using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1700A_GUI
{
    public static class CalController
    {

        public static string[] cmd = new string[] {"SYS:CAL:MODE ON", 
        "SYS:CAL:MODE OFF",

        "PS1:CAL:VOLT:AUTO",
        "PS1:CAL:VOLT?",
        "PS1:CAL:RES #",
        "PS1:CAL:RES?",
        "PS1:CAL LC_MIN",
        "PS1:CAL LC_MAX",
        "PS1:CAL HC_MIN",
        "PS1:CAL HC_MAX",
        "PS1:CAL?",
        "PS1:CAL:APPLY",
        "CM1:CAL LC_MIN",
        "CM1:CAL LC_MAX",
        "CM1:CAL HC_MIN",
        "CM1:CAL HC_MAX",
        "CM1:CAL:APPLY",
        "CM1:CAL?",
        "SYS:SELFTEST"};
        public static Form1 f = null;
        public static void init()
        {
            int idx = 1;
            foreach (var c in cmd)
            {
                var arr = f.Controls.Find("cal" + idx.ToString(), true);
                Button btn = (Button) arr[0];
                btn.Text = c;
                idx++;
            }
        }
    }
}
