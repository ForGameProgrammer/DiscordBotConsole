using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DiscordBotConsole
{
    class Constants
    {
        public static string LOGDOSYASI = "Log.txt";
        public static string TOKEN = "MzU0MzkyMzUzMjkwNzE1MTM4.DI9ltg.k9ZC5sT1_0XW2REnVuBRzi-18ac";
        public static string VERITABANI = "Veriler.sqlite";
        public static string TABLO = "Tablo";
        public static string ROW_KULLANICI_ID = "kId";
        public static string ROW_PUAN = "puan";
        public static string TABLOOLUSTUR = $"CREATE TABLE IF NOT EXISTS {TABLO} ({ROW_KULLANICI_ID} int, {ROW_PUAN} int)";
        public static SQLiteConnection SQLCONNECTION;
        public static ulong FORGAMER = 136243252289470464;
        public static ulong KEFARET = 309717542480510977;
        public static ulong ECE = 268393086428643330;  
        public static ulong CEMAL = 143660279287250944;
        public static ulong YURUYENBASE = 256545309738532864;
        public static ulong PAKUN = 291247416760467456;
        public static ulong LUX = 325763309057998848;
        public static ulong GUCKFOSU = 189807950741635072;

    }
}
