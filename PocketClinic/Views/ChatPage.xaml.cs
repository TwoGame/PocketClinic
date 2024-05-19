using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketClinic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        ObservableCollection<ChatMessage> chatMessages = new ObservableCollection<ChatMessage>();

        public ChatPage()
        {
            InitializeComponent();
            ChatListView.ItemsSource = chatMessages;
        }

        private void OnMessageEntryCompleted(object sender, EventArgs e)
        {
            string message = MessageEntry.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                string botResponse = ChatBotService.GetBotResponse(message);

                chatMessages.Add(new ChatMessage { Text = message, IsBotMessage = false });
                chatMessages.Add(new ChatMessage { Text = botResponse, IsBotMessage = true });

                MessageEntry.Text = string.Empty;
            }
        }


    }

    public class ChatMessage
    {
        public string Text { get; set; }
        public bool IsBotMessage { get; set; }
    }

    public class ChatBotService
    {
        public static string GetBotResponse(string question)
        {
            // Простая логика для ответов на определенные вопросы.
            switch (question.ToLower())
            {
                case "как померить температуру":
                    return "Для измерения температуры используйте термометр.";
                case "как вылечить простуду":
                    return "Для лечения простуды рекомендуется пить горячие напитки и отдыхать.";
                default:
                    return "Извините, я не понимаю ваш вопрос.";
            }
        }
    }
}