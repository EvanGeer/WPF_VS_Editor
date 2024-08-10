using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Windows;


namespace WPF_VS_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string MonacoFolder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"Monaco");

        const string defaultText = @"function helloWorld() {\n\tconsole.log(""Hello world!"");\n}"; 
        public string Text { get; private set; } = defaultText;

        public MainWindow()
        {
            InitializeComponent();

            webView21.NavigationCompleted += WebView21_NavigationCompleted;
            webView21.WebMessageReceived += WebView21_WebMessageReceived;

            webView21.Source = new Uri(Path.Combine(MonacoFolder, "index.html"));
        }

        private void WebView21_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            webView21.ExecuteScriptAsync(@$"buildEditor(`{Text}`);");
        }

        private void WebView21_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            Text = e.TryGetWebMessageAsString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Text);
        }
    }
}