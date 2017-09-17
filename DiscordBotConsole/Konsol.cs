using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiscordBotConsole
{
    public static class Konsol
    {
        public static void WriteLine(string str)
        {
            Console.WriteLine(str);
            File.AppendAllText(Constants.LOGDOSYASI, str + Environment.NewLine);
        }
        public static void Write(string str)
        {
            Console.WriteLine(str);
            File.AppendAllText(Constants.LOGDOSYASI, str);
        }
    }
}
