using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsCheckers
{
    internal static class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            FormsManager.RunCheckers();
        }
    }
}
