using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calc
{

    public partial class MainWindow : Window
    {
        string[] resultHistory = new string[100];
        public delegate double Calculating(string a, string b, string operation);
        Calculating getResult = Calculate.solution;
        string a, b, operation, clear;
        bool isOperatorused = false;
        bool isExecuteused = false;
        bool justClickedExecute = false;






        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickOperation(object sender, RoutedEventArgs e)
        {
            if (isOperatorused)

                return;

            if (Result.Text.Equals(""))
                Result.Text = (String)((Button)sender).Content;
            else

                Result.Text += (String)((Button)sender).Content;
            isOperatorused = true;
            operation = (String)((Button)sender).Name;
            Result.Text = "";
        }

        private void buttonClickNumeral(object sender, RoutedEventArgs e)
        {
            if (Result.Text.Contains(",") && ((String)((Button)sender).Content).Equals(","))
            {
                return;
            }
            if (justClickedExecute && !isOperatorused)
            {
                Button clear = new Button();
                clear.Content = "C";
                TextRemoving(clear, e);
                Result.Text = (String)((Button)sender).Content;
                a = Result.Text;
                justClickedExecute = false;
                return;
            }


            if (Result.Text.Equals(""))
                Result.Text = (String)((Button)sender).Content;

            else
                Result.Text += (String)((Button)sender).Content;
            if (!isOperatorused)
            {
                a += (String)((Button)sender).Content;

            }
            else
                b += (String)((Button)sender).Content;

            justClickedExecute = false;

        }



        private void TextRemoving(object sender, RoutedEventArgs e)
        {
            clear = (String)((Button)sender).Content;

            switch (clear)
            {
                case "CE":
                    a = "";
                    b = "";
                    operation = "";
                    Result.Text = "";
                    break;
                case "C":

                    if (isExecuteused)
                    {

                        a = "";
                        b = "";
                        operation = "";
                        Result.Text = "";
                        break;
                    }
                    else
                    {

                        if (isOperatorused)
                        {
                            b = "";
                            Result.Text = "";
                            break;
                        }
                        else
                        {
                            a = "";
                            Result.Text = "";
                            break;
                        }
                    }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void CheckBox_Clear(object sender, RoutedEventArgs e)
        {
            display.Items.Clear();


        }

        private void Clearing(object sender, RoutedEventArgs e)
        {
            display.Items.Clear();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            display.Visibility = Visibility.Visible;
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            display.Visibility = Visibility.Hidden;
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            if (Result.Text.Equals(""))
                Result.Text = (String)((Button)sender).Content;

            else

                Result.Text += (String)((Button)sender).Content;
            Result.Text = "";
            Result.Text = getResult(a, b, operation).ToString();
            a = Result.Text;
            b = "";
            isOperatorused = false;
            isExecuteused = true;
            justClickedExecute = true;
            display.Items.Add(String.Concat(display.Items.Count + 1, ". " + Result.Text));



        }
    }
}
