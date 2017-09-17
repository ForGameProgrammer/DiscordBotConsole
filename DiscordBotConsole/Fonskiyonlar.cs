using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBotConsole
{
    class Fonksiyonlar
    {

        public static void KullaniciKontrol(SQLiteConnection con, ulong id)
        {
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {Constants.TABLO} WHERE ({Constants.ROW_KULLANICI_ID}={id})", con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                SQLiteCommand cmdekle = new SQLiteCommand($"INSERT INTO {Constants.TABLO} VALUES ({id}, 100)", con);
                cmdekle.ExecuteNonQuery();
            }
        }

        public static long KullaniciPuanBul(SQLiteConnection con, ulong id)
        {
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {Constants.TABLO} WHERE ({Constants.ROW_KULLANICI_ID}={id})", con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                SQLiteCommand cmdekle = new SQLiteCommand($"INSERT INTO {Constants.TABLO} VALUES ({id}, 100)", con);
                cmdekle.ExecuteNonQuery();
                return 100L;
            }
            reader.Read();
            return reader.GetInt64(1);
        }
        public static void KullaniciPuanEkle(SQLiteConnection con, ulong id, long puan)
        {
            KullaniciKontrol(con, id);
            SQLiteCommand cmd = new SQLiteCommand($"UPDATE {Constants.TABLO} SET {Constants.ROW_PUAN} = {Constants.ROW_PUAN} + {puan} WHERE ({Constants.ROW_KULLANICI_ID}={id})", con);
            cmd.ExecuteNonQuery();
        }
        public static void KullaniciPuanDegistir(SQLiteConnection con, ulong id, long puan)
        {
            KullaniciKontrol(con, id);
            SQLiteCommand cmd = new SQLiteCommand($"UPDATE {Constants.TABLO} SET {Constants.ROW_PUAN} = {puan} WHERE ({Constants.ROW_KULLANICI_ID}={id})", con);
            cmd.ExecuteNonQuery();
        }

        public static void TumHerkesePuanVer(SQLiteConnection con, long puan)
        {
            SQLiteCommand cmd = new SQLiteCommand($"UPDATE {Constants.TABLO} SET {Constants.ROW_PUAN} = {Constants.ROW_PUAN} + {puan}", con);
            cmd.ExecuteNonQuery();
        }

        public static Dictionary<ulong, long> PuanSiralamasi(SQLiteConnection con, int sinir = 10)
        {
            Dictionary<ulong, long> users = new Dictionary<ulong, long>();
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {Constants.TABLO} ORDER BY {Constants.ROW_PUAN} DESC LIMIT {sinir}", con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add((ulong)reader.GetInt64(0), reader.GetInt64(1));
            }
            return users;
        }

    }
}
