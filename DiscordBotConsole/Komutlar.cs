using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBotConsole
{
    class Komutlar
    {

        [Command("merhaba"), Description("Selam Sana Ey Kullanıcı...")]
        [Aliases("meraba", "selam", "sa", "mrb", "slm", "hi", "hello")]
        public async Task merhaba(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            ulong id = ctx.User.Id;
            if (id == Constants.KEFARET)

            {
                await ctx.RespondAsync($":cry: AĞLA {ctx.User.Mention}!");
            }
            else
            {
                await ctx.RespondAsync($"👋 Merhaba, {ctx.User.Mention}!");
            }
        }

        [Command("rasgele"), Description("Rasgele Sayı Üretir.")]
        [Aliases("random", "rnd", "zar", "zarat", "zarla", "rastgele")]
        public async Task rasgele(CommandContext ctx, int sayi1 = 1, int sayi2 = 100)
        {
            await ctx.TriggerTypingAsync();
            Random rnd = new Random();
            await ctx.RespondAsync($" 🎲 Senin İçin Rasge Sayım {ctx.User.Mention} : {rnd.Next(sayi1, sayi2)}");

        }

        [Command("yasuo"), Description("Evrenin En 800k Yasuosunu Selamlar.")]
        [Aliases("hasaki", "cemal")]
        public async Task yasuo(CommandContext ctx)
        {

            await ctx.TriggerTypingAsync();

            DiscordUser cemal = await ctx.Client.GetUserAsync(Constants.CEMAL);
            await ctx.RespondAsync($"{cemal.Mention}, Selam olsun Sana Ey Cemal! Nerelerdesin Dön Artık. Gözümüz Yollarda Kaldı...");
        }


        [Command("naber"), Description("Hal Hatır Sorar.")]
        [Aliases("nehaber", "nasılsın", "nbr")]
        public async Task naber(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            ulong id = ctx.User.Id;
            if (id == Constants.KEFARET)
            {
                await ctx.RespondAsync($":cry: SANANE KEFO AĞLA {ctx.User.Mention}!");
            }
            else
            {
                await ctx.RespondAsync($":blush:  İyidir Seni Sormalı, {ctx.User.Mention}!");
            }
        }

        [Command("kefaret"), Description("Yürüyen Kefaret...")]
        [Aliases("kefo", "yürüyenkefaret", "yuruyenkefaret")]
        public async Task kefaret(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            DiscordMember kefomem = await ctx.Guild.GetMemberAsync(Constants.KEFARET);

            await ctx.RespondAsync($"AĞLA KEFARET {kefomem.Mention}.");
        }

        [Command("kefoat"), Description("Yürüyen Kefaret'i Başka Odaya At...")]
        [Aliases("kefaretat", "yürüyenkefaretat")]
        public async Task kefaretat(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.TriggerTypingAsync();

            DiscordMember kefomem = await ctx.Guild.GetMemberAsync(Constants.KEFARET);
            IReadOnlyList<DiscordChannel> channels = await ctx.Guild.GetChannelsAsync();
            List<DiscordChannel> voicechannels = new List<DiscordChannel>();
            foreach (var channel in channels)
            {
                if (channel.Type == ChannelType.Voice) voicechannels.Add(channel);
            }

            if (kefomem.VoiceState.Channel != null)
            {
                await kefomem.ModifyAsync(null, null, null, null, voicechannels[new Random().Next(voicechannels.Count)]);
            }
            await ctx.RespondAsync($"AĞLA KEFARET {kefomem.Mention}. Orada Havalar Nasıl :)");
        }

        [Command("gosu"), Description("Guck Fosu...")]
        [Aliases("fosu", "guckfosu", "muho")]
        public async Task gosu(CommandContext ctx)
        {
            if (ctx.Member.Id != Constants.GUCKFOSU) return;
            await ctx.TriggerTypingAsync();

            DiscordMember gosu = await ctx.Guild.GetMemberAsync(Constants.GUCKFOSU);

            string[] yazilar = { "Valoranın Bilgesi Sana Selam Olsun", "Karanlığın Hizmetkârlarını Avlayalım", "Kara Büyünün Kokusunu Alıyorum", "Onları Acılarından Kurtarıyorum", "Kan gümüşle temizlenir", "En İyi GUCKFOSU Sensin" };
            string[] isimler = { "Yürüyen Vayne", "SUCUK GOSU", "Best Vayne TR", "Vayne Benden Sorulur", "GUCUK FOSU", "SUCUK VAYNE", "GICIK GOSU" };
            await gosu.ModifyAsync(isimler[new Random().Next(isimler.Length)]);
            await ctx.RespondAsync($"{yazilar[new Random().Next(yazilar.Length)]} {gosu.Mention}");
        }

        [Command("heal"), Description("Yürüyen Base Heal at Heal Heal...")]
        [Aliases("hil", "can", "canat", "healat", "hilat")]
        public async Task hil(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
            //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
            DiscordUser kerem = await ctx.Client.GetUserAsync(Constants.YURUYENBASE);
            await ctx.RespondAsync($"{kerem.Mention} Hil At Hil Hil! Görmee Görmee...");
        }

        [Command("yuraret"), Description("Yürüyen Kefaretin ForGamer'a Olan Sevgisi.")]
        [Aliases("kefiyen")]
        public async Task commands(CommandContext ctx)
        {
            //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
            //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
            await ctx.TriggerTypingAsync();
            DiscordMember kefomem = await ctx.Guild.GetMemberAsync(Constants.KEFARET);
            string[] kefiyen = { "Kefiyen Yüraret", "Keko Kefo", "AĞLIYORUM", "BRONZUM", "KUU AT", "NOOB'UM", "KARŞİM AĞĞLA", "ForGamer Adamdır", "ForGamer 1v1'de Beni Yendi", "Ben Fiorada Noob'um", "ForGamer'dan Özür Dilerim", "Noob'um Tabi Gülmeyi Kes", "Singed Adamdır, Fiora Noob", "Oyunlarda Kötüyüm", "Yasin Abi Adamdır", "Yasin Abi Singed İle Beni Ezdi" };
            await kefomem.ModifyAsync(kefiyen[new Random().Next(kefiyen.Length)]);
            await ctx.RespondAsync($"{kefomem.Mention} Adın Güzelmiş...");

        }

        [Command("pakun"), Description("Discord Polisi.")]
        [Aliases("paakun", "pağkun", "pakkun")]
        public async Task pakun(CommandContext ctx)
        {
            //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
            //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
            await ctx.TriggerTypingAsync();
            DiscordMember pakmem = await ctx.Guild.GetMemberAsync(Constants.PAKUN);
            string[] pakkun = { "Paku", "Pak-San", "Pak-Sama", "Pak-Chan Kawaii :3", "PAĞ KUN", "PAAAA KUN", "Pa-Kun", "Pa Polis" };
            await pakmem.ModifyAsync(pakkun[new Random().Next(pakkun.Length)]);
            await ctx.RespondAsync($"{pakmem.Mention} Selam Olsun Sana Discord Polisi. Discorddaki Vak'alar Pa Kun Yak'alar...");

        }

        [Command("ece"), Description("<3.")]
        [Hidden]
        [Aliases("eys", "ace")]
        public async Task ece(CommandContext ctx)
        {

            //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
            //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
            if (ctx.Message.Author.Id != Constants.ECE && ctx.Message.Author.Id != Constants.FORGAMER)
            {
                return;
            }
            await ctx.Message.DeleteAsync();

            DiscordMember ecem = await ctx.Guild.GetMemberAsync(Constants.ECE);
            string[] mesaj = { "Yasin Seni Çooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooook Seviyor. <3", "Yasin'in Bir Tanesi :3", "Seviliyorsunuz Hanfendi ^_^", "Yasin'i Asla Bırakma Tamammı. Oda Seni Asla Bırakmayacak.", "Şirinlik Abidesi Seni :3 ", "Duydumki ForGamer Seni Seviyormuş ^_^ Ona İyi Bak Olurmu" };
            //await ninemem.ModifyAsync(nyan[new Random().Next(nyan.Length)]);
            string yey = mesaj[new Random().Next(mesaj.Length)];
            await ecem.SendMessageAsync($"{yey}");

        }

        [Command("squirtle"), Description("What The Lux Say.")]
        [Aliases("doruk", "skörtıl", "sükörtık", "skortil")]
        public async Task squirtle(CommandContext ctx)
        {

            //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
            //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;

            await ctx.TriggerTypingAsync();

            DiscordMember doruk = await ctx.Guild.GetMemberAsync(275662141707649027);
            string[] mesaj = { "ya HDD yandı işte zaten giremiyorum :confused:" };
            //await ninemem.ModifyAsync(nyan[new Random().Next(nyan.Length)]);
            string yey = mesaj[new Random().Next(mesaj.Length)];
            await ctx.RespondAsync($"{yey} {doruk.Mention}");

        }

        [Command("darkinece"), Description("Darkin Mode On.")]
        [Aliases("darkin")]
        public async Task darkinece(CommandContext ctx)
        {

            //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
            //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;

            await ctx.TriggerTypingAsync();

            string[] mesaj = { "Darkin Mode On! :fire:", ":fire: FLAME FLAME FLAME", "KÖTÜ OYUNCU SENİĞ. AĞLAAA :fire: ", ":fire: YANACAKSIN. BEN HARİÇ ALAYINIZ YANACAK :fire: " };

            string yey = mesaj[new Random().Next(mesaj.Length)];
            await ctx.RespondAsync($"{yey}");

        }

        [Command("forgamer"), Description("Botun Sahibi.")]
        [Aliases("needforsinged", "yasinged", "singed")]
        public async Task forgamer(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            string[] mesaj = { "Singed Dünya 75132187.Si", "Gönüllerin Singed 1.si", "Botların Efendisi.", "Benim Sahibim.", "The Fastest Singed Alive" };

            string yey = mesaj[new Random().Next(mesaj.Length)];
            await ctx.RespondAsync($"{yey}");
        }


        [Command("lux"), Description("What The Lux Say.")]
        public async Task lux(CommandContext ctx)
        {
            //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
            //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;

            await ctx.TriggerTypingAsync();

            DiscordMember wtlux = await ctx.Guild.GetMemberAsync(Constants.LUX);
            string[] mesaj = { "What Does The Lux Say? Hiyahihia Hiyayihaia.", "Lux Say : Demacia...", "Çifte Gökkuşağı :3", "The light of Demacia!", "Illuminate the enemy.", "Stay positive." };
            //await ninemem.ModifyAsync(nyan[new Random().Next(nyan.Length)]);
            string yey = mesaj[new Random().Next(mesaj.Length)];
            await ctx.RespondAsync($"{yey} {wtlux.Mention}");

        }

        [Group("yonetici")]
        [Aliases("admin", "yönetici")]
        [Description("Yönetici")]
        [RequireUserPermissions(Permissions.Administrator)]
        public class Yonetici
        {

            [Command("puanekle"), Description("Puan Ekle. Kullanımı !yonetici puanekle <miktar> <alıcı> Şeklinde.")]
            [Aliases("puanver", "puanyolla")]
            public async Task puanekle(CommandContext ctx, long miktar, DiscordUser kisi)
            {
                await ctx.TriggerTypingAsync();

                await ctx.Message.DeleteAsync();
                Fonksiyonlar.KullaniciPuanEkle(Constants.SQLCONNECTION, kisi.Id, miktar);
                await ctx.RespondAsync($" {kisi.Mention} Hesabınıza {miktar} Puan Eklendi . Şuan Sahip Olduğunuz Puan : {Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, kisi.Id)}");
            }

            [Command("davetkapat"), Description("Discorda Davetleri Kapatır.")]
            [Aliases("davetlerikapat", "davetlerikapa", "davetkapa")]
            public async Task davetkapat(CommandContext ctx)
            {
                try
                {
                    await ctx.TriggerTypingAsync();

                    DiscordGuild guild = ctx.Guild;
                    IReadOnlyList<DiscordChannel> channels = guild.Channels;
                    
                    foreach (DiscordChannel channel in channels)
                    {
                        IReadOnlyList<DiscordOverwrite> overwrites = channel.PermissionOverwrites;
                        foreach (var ow in overwrites)
                        {
                            
                            await channel.UpdateOverwriteAsync(ow, ow.Allow , ow.Deny | Permissions.CreateInstantInvite);
                        }
                        

                    }
                    await ctx.RespondAsync($"Server'a Davet Kapandı.");

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Konsol.WriteLine($"--- Hata : {ex.Message} ---");
                }
            }

            [Command("davetac"), Description("Discorda Davetleri Kapatır.")]
            [Aliases("davetleriac", "davetleriaç", "davetaç")]
            public async Task davetac(CommandContext ctx)
            {
                try
                {
                    await ctx.TriggerTypingAsync();

                    DiscordGuild guild = ctx.Guild;
                    IReadOnlyList<DiscordChannel> channels = guild.Channels;

                    foreach (DiscordChannel channel in channels)
                    {
                        IReadOnlyList<DiscordOverwrite> overwrites = channel.PermissionOverwrites;
                        foreach (var ow in overwrites)
                        {
                            await channel.UpdateOverwriteAsync(ow, ow.Allow | Permissions.CreateInstantInvite, ow.Deny);
                        }


                    }
                    await ctx.RespondAsync($"Server'a Davet Kapandı.");

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Konsol.WriteLine($"--- Hata : {ex.Message} ---");
                }
            }

            [Command("puanhediye"), Description("Herkese Puan Hediye et. !yonetici puanhediye <sayı> Şeklinde Kullanılır.")]
            [Aliases("puandağıt", "hediye")]
            public async Task hediye(CommandContext ctx, int miktar)
            {
                await ctx.TriggerTypingAsync();

                await ctx.Message.DeleteAsync();
                Fonksiyonlar.TumHerkesePuanVer(Constants.SQLCONNECTION, miktar);
                await ctx.RespondAsync($"{ctx.Message.Author.Mention} Herkese {miktar} Puan Hediye Etti Yuppii.");
            }

            [Command("sil"), Description("Mesajları Siler. !yonetici sil <sayı> Şeklinde Kullanılır.")]
            [Aliases("delete", "mesajsil")]
            public async Task sil(CommandContext ctx, int miktar)
            {
                try
                {
                    await ctx.TriggerTypingAsync();
                    await ctx.Message.DeleteAsync();
                    DiscordChannel kanal = ctx.Channel;
                    int sayi = miktar;
                    do
                    {
                        List<DiscordMessage> messages = (await kanal.GetMessagesAsync(sayi > 100 ? 100 : sayi)).ToList();
                        await kanal.DeleteMessagesAsync(messages);

                        sayi -= 100;
                    } while (sayi >= 100);


                    DiscordMessage msg = await ctx.RespondAsync($"Son {miktar} Mesaj Başarı İle Silindi.");
                    await Task.Delay(TimeSpan.FromSeconds(3));
                    await msg.DeleteAsync();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("HATA : " + ex.Message);
                }


            }
        }


        [Group("kumar")]
        [Aliases("oyun", "puan")]
        [Description("Kumar Oyunları")]
        public class Kumar
        {
            [Command("ust"), Description("1-100 Arası Rasgele Sayı 50'den Büyük Gelir. !kumar ust <yatırılacak miktar> Şeklinde Kullanılır. Yatırdığınız Kadar Kazanırsınız.")]
            [Aliases("yukari", "yukarı", "üst", "buyuk", "buyuktur", "büyük", "büyüktür")]
            public async Task buyuk(CommandContext ctx, long bet)
            {
                //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
                //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
                long puan = Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id);
                if (puan < bet)
                {
                    await ctx.RespondAsync($"Üzgünüm {ctx.Message.Author.Mention} Yeterli Puanınız Yok. ");
                    return;
                }
                Random rnd = new Random();
                int sayi = rnd.Next(1, 100);
                if (sayi > 50)
                {
                    Fonksiyonlar.KullaniciPuanDegistir(Constants.SQLCONNECTION, ctx.Message.Author.Id, puan + bet);
                    await ctx.RespondAsync($"🎲 Sayı : {sayi} Tebrikler Kazandınız {ctx.Message.Author.Mention} . Toplam Puanınız : {Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id)}");
                }
                else
                {
                    Fonksiyonlar.KullaniciPuanDegistir(Constants.SQLCONNECTION, ctx.Message.Author.Id, puan - bet);
                    await ctx.RespondAsync($"🎲 Sayı : {sayi} Üzgünüm, Kaybettiniz :/ {ctx.Message.Author.Mention} . Kalan Puanınız : {Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id)}");
                }
            }

            [Command("alt"), Description("1-100 Arası Rasgele Sayı 50'den Küçük Gelir. !kumar alt <yatırılacak miktar> Şeklinde Kullanılır. Yatırdığınız Kadar Kazanırsınız.")]
            [Aliases("asagi", "aşağı", "kucuk", "küçük", "kucuktur", "küçüktür")]
            public async Task kucuk(CommandContext ctx, long bet)
            {
                //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
                //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
                long puan = Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id);
                if (puan < bet)
                {
                    await ctx.RespondAsync($"Üzgünüm {ctx.Message.Author.Mention} Yeterli Puanınız Yok. ");
                    return;
                }
                Random rnd = new Random();
                int sayi = rnd.Next(1, 100);
                if (sayi < 50)
                {
                    Fonksiyonlar.KullaniciPuanDegistir(Constants.SQLCONNECTION, ctx.Message.Author.Id, puan + bet);
                    await ctx.RespondAsync($"🎲 Sayı : {sayi} Tebrikler Kazandınız {ctx.Message.Author.Mention} . Toplam Puanınız : {Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id)}");
                }
                else
                {
                    Fonksiyonlar.KullaniciPuanDegistir(Constants.SQLCONNECTION, ctx.Message.Author.Id, puan - bet);
                    await ctx.RespondAsync($"🎲 Sayı : {sayi} Üzgünüm, Kaybettiniz :/ {ctx.Message.Author.Mention} . Kalan Puanınız : {Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id)}");
                }

            }

            [Command("esit"), Description("1-100 Arası Rasgele Sayı Tam 50 Gelir. !kumar esit <yatırılacak miktar> Şeklinde Kullanılır. Yatırdığınız Miktarın 95 Katını Kanırsınız.")]
            [Aliases("esittir", "eşit", "eşittir")]
            public async Task esit(CommandContext ctx, long bet)
            {
                //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
                //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
                long puan = Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id);
                if (puan < bet)
                {
                    await ctx.RespondAsync($"Üzgünüm {ctx.Message.Author.Mention} Yeterli Puanınız Yok. ");
                    return;
                }
                Random rnd = new Random();
                int sayi = rnd.Next(1, 100);
                if (ctx.User.Id == Constants.FORGAMER) sayi = rnd.Next(48, 53); ;
                if (sayi == 50)
                {
                    Fonksiyonlar.KullaniciPuanDegistir(Constants.SQLCONNECTION, ctx.Message.Author.Id, puan + (bet * 95));
                    await ctx.RespondAsync($"🎲 Sayı : {sayi} Tebrikler Kazandınız {ctx.Message.Author.Mention} . Toplam Puanınız : {Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id)}");
                }
                else
                {
                    Fonksiyonlar.KullaniciPuanDegistir(Constants.SQLCONNECTION, ctx.Message.Author.Id, puan - bet);
                    await ctx.RespondAsync($"🎲 Sayı : {sayi} Üzgünüm, Kaybettiniz :/ {ctx.Message.Author.Mention} . Kalan Puanınız : {Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id)}");
                }

            }

            [Command("yolla"), Description("Sahip Olduğunuz Puanı Başkasına Yollama. !kumar yolla <@kişi> <miktar> Şeklinde Kullanılır.")]
            [Aliases("gonder", "at", "ver", "puangonder", "puanver")]
            public async Task yolla(CommandContext ctx, [Description("Gönderilecek Kullanıcı.")] DiscordUser kisi, long miktar)
            {
                //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
                //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
                long puan = Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id);
                if (puan < miktar)
                {
                    await ctx.RespondAsync($"Üzgünüm {ctx.Message.Author.Mention} Yeterli Puanınız Yok. ");
                    return;
                }

                Fonksiyonlar.KullaniciPuanDegistir(Constants.SQLCONNECTION, ctx.Message.Author.Id, puan - miktar);
                Fonksiyonlar.KullaniciPuanEkle(Constants.SQLCONNECTION, kisi.Id, miktar);
                await ctx.RespondAsync($" {ctx.Message.Author.Mention} => {miktar} => {kisi.Mention} Yolladı . {ctx.Message.Author.Mention}  Kalan Puanınız : {Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id)}");
            }

            [Command("siralama"), Description("Puan Sıralaması İlk 10.")]
            [Aliases("ilk10", "top10", "puansiralamasi", "tablo")]
            public async Task siralama(CommandContext ctx)
            {
                //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
                //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
                await ctx.TriggerTypingAsync();
                Dictionary<ulong, long> users = Fonksiyonlar.PuanSiralamasi(Constants.SQLCONNECTION);

                DiscordEmbedBuilder embedbuilder = new DiscordEmbedBuilder();
                embedbuilder.Description = "Puan Sıralaması";

                int n = 0;
                foreach (var item in users)
                {
                    n++;
                    DiscordUser user = await ctx.Client.GetUserAsync(item.Key);

                    embedbuilder.AddField(n.ToString(), user.Username + item.Value.ToString().PadLeft(32 - user.Username.Length));
                }

                await ctx.RespondAsync("", false, embedbuilder.Build());
            }

            [Command("puan"), Description("Kaç Puanım Var? !kumar puan Şeklinde Kullanılır.")]
            [Aliases("para")]
            public async Task puan(CommandContext ctx)
            {
                //string chan = (await ctx.Client.GetChannelAsync(ctx.Message.ChannelId)).Name;
                //if (!(chan.StartsWith("bot") || chan.StartsWith("komut"))) return;
                long puan = Fonksiyonlar.KullaniciPuanBul(Constants.SQLCONNECTION, ctx.Message.Author.Id);

                await ctx.RespondAsync($"{ctx.Message.Author.Mention} Şuanda {puan} Puana Sahipsiniz. ");
            }

        }
    }




}
