using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;

namespace DISCORD_BOT.CommandHandler
{
    public class Handler : ModuleBase<SocketCommandContext>
    {
        async Task SendMessageAsync(string message, bool inTTS = false, Embed embed = null)
        {
            if(embed == null)
            {
                Console.WriteLine($"{DateTime.Now} [ACT] [{Context.Guild}．{Context.Channel}] {message}" );
                await Context.Channel.SendMessageAsync(message, inTTS);
            }
            else
            {
                Console.WriteLine($"{DateTime.Now} [ACT] [{Context.Guild}．{Context.Channel}] (EMBED MESSAGE)" );
                await Context.Channel.SendMessageAsync(message, inTTS, embed);
            }
        }


        [Command("illya intro"), Alias("☆intro"), Summary("reply")]
        public async Task in01()
        {
            await SendMessageAsync("伊莉雅，小學五年級生\n幹魔法女孩的工作，嗯。");
            await SendMessageAsync("目前的任務是計算chouguting_I的公正性，這樣");
        }

        [Command("☆test"), Summary("TEST2")]
        public async Task in02()
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor(Context.User.Username, Context.User.GetAvatarUrl());
            eb.WithColor(70,201,196);
            eb.WithFooter("WithFooter", "https://discordapp.com/assets/5c5bb53489a0a9f602df0a24c5981523.svg");
            eb.AddField("AddField", 87);

            await SendMessageAsync("", false, eb.Build());
        }

        [Command("☆drinkstart"), Summary("TEST3")]
        public async Task in03()
        {
            await SendMessageAsync("好，讓我們開始吧！");
            await SendMessageAsync("喝啥飲料");
        }
    }
}