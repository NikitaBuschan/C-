using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using One.Core;
using One.Core.Habra;

namespace One
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ParserWorker<string[]> parser;

        public MainWindow()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                    new AutoProParser()
                );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (var item in arg2)
            {
                List.Items.Add(item);
            }
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            parser.Settings = new AutoProSettings();
            parser.Start();
        }

        private void ButtonAbort_Click(object sender, RoutedEventArgs e)
        {
            parser.Abort();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
