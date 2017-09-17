using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.IO;

namespace DiscordBotConsole
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);

        DiscordClient client;
        Olaylar events;
        static CommandsNextModule commands;



        static void Main(string[] args)
        {

            new Program().start().GetAwaiter().GetResult();
        }

        public async Task start()
        {
            //Console Closing Event
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);

            VeriTabaniOlustur();

            DiscordConfiguration config = new DiscordConfiguration();
            config.TokenType = TokenType.Bot;
            config.Token = Constants.TOKEN;
            //config.LogLevel = LogLevel.Debug;
            //config.UseInternalLogHandler = true;

            client = new DiscordClient(config);

            events = new Olaylar(client);

            client.Ready += events.Ready;
            client.ClientErrored += events.ClientErrored;
            client.MessageCreated += events.MessageCreated;
            client.SocketClosed += events.SocketClosed;
            client.GuildMemberUpdated += events.GuildMemberUpdated;
            client.GuildMemberAdded += events.GuildMemberAdded;
            client.GuildMemberRemoved += events.MemberRemoved;
            client.MessageDeleted += events.MessageDeleted;
            client.MessageUpdated += events.MessageUpdated;

            // finnaly, let's connect and log in
            commands = client.UseCommandsNext(new CommandsNextConfiguration { StringPrefix = "!" });
            commands.RegisterCommands<Komutlar>();

            await client.ConnectAsync();
            await Task.Delay(-1);
        }


        private bool ConsoleEventCallback(int eventType)
        {
            client.DisconnectAsync().GetAwaiter().GetResult();
            client.Dispose();

            return false;
        }

        void VeriTabaniOlustur()
        {
            if (!System.IO.File.Exists(Constants.VERITABANI))
            {
                SQLiteConnection.CreateFile(Constants.VERITABANI);
            }
            SQLiteConnection sqliteconnection = new SQLiteConnection($"Data Source = {Constants.VERITABANI}; Version = 3;");
            sqliteconnection.Open();
            Constants.SQLCONNECTION = sqliteconnection;
            SQLiteCommand cmd = new SQLiteCommand(Constants.TABLOOLUSTUR, Constants.SQLCONNECTION);
            cmd.ExecuteNonQuery();
        }

    }
}
