using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Data.SQLite;
using System.IO;
using DSharpPlus.EventArgs;

namespace DiscordBotConsole
{
    class Olaylar
    {
        public DiscordClient client;

        public Olaylar(DiscordClient cl)
        {
            this.client = cl;
        }

        public async Task<Task> GuildMemberUpdated(DSharpPlus.EventArgs.GuildMemberUpdateEventArgs e)
        {
            

            return Task.Delay(0);
        }

        public Task SocketClosed(DSharpPlus.EventArgs.SocketCloseEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Konsol.WriteLine("--- Bot Durduruldu ---");

            return Task.Delay(0);
        }

        public Task MessageCreated(DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Konsol.WriteLine(e.Message.Timestamp.ToString() + " -> Sunucu : " + e.Guild.Name + " -> Kanal : "  + e.Channel.Name + " -> Kullanıcı : " + e.Author.Username + " -> Mesaj : " + e.Message.Content);
            
            return Task.Delay(0);
        }

        public async Task<Task> MemberRemoved(GuildMemberRemoveEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Konsol.WriteLine($"--- {e.Member.Username} - {e.Guild.Name} Sunucusundan Ayrıldı ---");

            return Task.Delay(0);
        }

        internal async Task<Task> MessageUpdated(MessageUpdateEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Konsol.WriteLine(DateTime.Now.ToString() + " -> Sunucu : " + e.Guild.Name + " -> Kanal : " + e.Channel.Name + " -> Kullanıcı : " + e.Message.Author.Username + " -> Mesajı Değiştirdi : " + e.Message.Content);
            
            return Task.Delay(0);
        }

        internal async Task<Task> MessageDeleted(MessageDeleteEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Konsol.WriteLine(DateTime.Now.ToString() + " -> Sunucu : " + e.Guild.Name + " -> Kanal : " + e.Channel.Name + " -> Kullanıcı : " + e.Message.Author.Username + " -> Mesajı Sildi : " + e.Message.Content);

            return Task.Delay(0);
        }

        public async Task<Task> GuildMemberAdded(GuildMemberAddEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Konsol.WriteLine($"--- {e.Member.Username} - {e.Guild.Name} Sunucusuna Katıldı ---");

            return Task.Delay(0);
        }

        public Task ClientErrored(DSharpPlus.EventArgs.ClientErrorEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Konsol.WriteLine($"--- Hata : {e.Exception.Message} ---");

            return Task.Delay(0);
        }
        
        public Task Ready(DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            client.UpdateStatusAsync(new DSharpPlus.Entities.Game("ForGamer Benimle"));
            Console.ForegroundColor = ConsoleColor.Green;
            Konsol.WriteLine("--- Bot Hazır ---");

            return Task.Delay(0);
        }
    }
}
