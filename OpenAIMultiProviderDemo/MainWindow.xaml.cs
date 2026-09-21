using OpenAI;
using OpenAI.Chat;
using OpenAIMultiProviderShared;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenAIMultiProviderDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnTest_Click(object sender, RoutedEventArgs e)
        {
            OpenAIClient oaiClient =  MultiProvider.GetOpenAIClient(MultiProvider.GetApiKey () );

            ChatClient client = oaiClient.GetChatClient(MultiProvider.ModelLow) ;


            ChatCompletion completion = await client.CompleteChatAsync("2 + 1 = ?");

            MessageBox.Show($"[ASSISTANT]: {completion.Content[0].Text}");
        }
    }
}