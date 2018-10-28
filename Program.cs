//JCxYIS#6705
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;

using DISCORD_BOT.Config;

namespace DISCORD_BOT
{
    class Program
    {
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        DiscordSocketClient client;
        CommandService command;
        static public ConfigFormat config;

        async Task MainAsync()
        {
            string jsonPath = Path.GetDirectoryName(
                Path.GetDirectoryName (Path.GetDirectoryName( Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) ) ) )
                + @"\Data\Config.json";
            string loadedJson = File.ReadAllText(jsonPath);
            config = JsonConvert.DeserializeObject<ConfigFormat>(loadedJson);
            Console.WriteLine("啟動中... 版本"+config.version);
            
            client = new DiscordSocketClient( new DiscordSocketConfig{LogLevel = LogSeverity.Debug} );
            command = new CommandService( 
                new CommandServiceConfig
                {
                    CaseSensitiveCommands = true,
                    DefaultRunMode = RunMode.Async,
                    LogLevel = LogSeverity.Debug
                });

            client.MessageReceived += onRecieve;
            await command.AddModulesAsync(Assembly.GetEntryAssembly());
            client.Ready += onReady;
            client.Log += onLog;
            await client.LoginAsync(TokenType.Bot, config.token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        async Task onRecieve(SocketMessage msgPara)
        {
            SocketUserMessage sum = msgPara as SocketUserMessage;
            var context = new SocketCommandContext(client, sum);

            Console.WriteLine($"{DateTime.Now} [GET] [{context.Guild}．{context.Channel}] {context.User}:{context.Message}" );
            
            if(string.IsNullOrEmpty(context.Message.ToString()))
                return;

            var result = await command.ExecuteAsync(context, 0);
        }
        
        async Task onReady()
        {
            await client.SetGameAsync("為什麼這個本本上會有我...?", null, ActivityType.Watching);
            Console.WriteLine($"{DateTime.Now} [READY]" );
        }

        async Task onLog(LogMessage msg)
        {
            Console.WriteLine($"{DateTime.Now} [LOG] {msg.Source}:{msg.Message}" );
            await Task.Delay(0);
        }
    }
}
