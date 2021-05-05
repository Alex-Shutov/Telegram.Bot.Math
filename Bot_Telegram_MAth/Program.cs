using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;

namespace Bot_Telegram_MAth
{
    
    class Program
    {
        public const string TOKEN = "1762733967:AAE6K3a89jQBypsboN9vJL834L1cZ7QJfBU";
        private static readonly ITelegramBotClient botClient = new TelegramBotClient(TOKEN);
        static void Main(string[] args)
        {
            //Console.WriteLine("Start");
            //botClient.OnMessage += Hook_OnMessage;
            //botClient.StartReceiving();
            //Console.WriteLine("Stop");
            //Console.ReadKey();
            //botClient.StopReceiving();
            try
            {
                Console.WriteLine("Start");
                botClient.OnMessage += Hook_OnMessage;
                botClient.StartReceiving();
                
                Console.Read();
                Console.WriteLine("Stop");
                botClient.StopReceiving();
            }
            catch (Exception e)
            {
                Console.WriteLine("The error was occured: " + e);
                throw;
            }



        }

        private static async void Hook_OnMessage(object? sender, MessageEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Message.Text))
            {
                Console.WriteLine("Get message from "+ e.Message.Chat.Id );
                switch (e.Message.Text)
                {
                    case var message when string.Equals(message, "/help", StringComparison.OrdinalIgnoreCase):
                        Message(e.Message.Chat, "Помощь");
                        break;
                   
                    case var message when string.Equals(message, "/hello", StringComparison.OrdinalIgnoreCase):
                        Message(e.Message.Chat,"Привет");
                        break; 
                    default: NoRecogizeMessage(e.Message.Chat);
                        break;
                }
            }
        }

        private static async void Message(Chat chatId, string message)
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: message);
        }

        private static async void NoRecogizeMessage(Chat chatId)
        {
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"I can't recognize your message.\n Please, try again");
        }
    }
}
