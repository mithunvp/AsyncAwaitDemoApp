using System;
using System.Windows;
using WordCountLib;

namespace WordCount.UI
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

        /// <summary>
        /// Button click Synchronous processing
        /// </summary>
        
        private  void btndwn_Click(object sender, RoutedEventArgs e)
        {
            Log("START");
            
            if (listBox.Visibility == Visibility.Visible)
            {
                listBox.Visibility = Visibility.Collapsed;
            }

            WordCountClass wrdSimple = new WordCountClass();            
            var listCount = wrdSimple.FindWordCounts();            
            listBox.Visibility = Visibility.Visible;
            listBoxasync.Visibility = Visibility.Collapsed;
            listBox.ItemsSource = listCount;            
            Log("Done ");
        }
        
        private async void btndwnasyn_Click(object sender, RoutedEventArgs e)
        {
            Log("START Async");
            if (listBoxasync.Visibility == Visibility.Visible)
            {
                listBoxasync.Visibility = Visibility.Collapsed;
            }
            WordCountClass wrdSimple = new WordCountClass();
            var listCount = await wrdSimple.FindWordCountsAsync();
            listBoxasync.Visibility = Visibility.Visible;
            listBox.Visibility = Visibility.Collapsed;
            listBoxasync.ItemsSource = listCount;
            
            Log("Done Async");
        }

        private void Log(string text)
        {
            string line = string.Format("{0:HH:mm:ss.fff}: {1}\r\n", DateTime.Now, text);
            logtxtBlock.AppendText(line);
        }
    }
}