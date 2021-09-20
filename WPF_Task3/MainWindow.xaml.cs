using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF_Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thickness LeftSide = new Thickness(-39, 0, 0, 0);
        Thickness RightSide = new Thickness(0, 0, -39, 0);
        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(75, 148, 227));
        private bool Toggled = false;
        public MainWindow()
        {
            InitializeComponent();
            Back.Fill = Off;
            Toggled = false;
            Dot.Margin = LeftSide;
        }
        public string Filename { get; set; }
        public bool Toggled1 { get => Toggled; set => Toggled = value; }

        public bool click { get; set; }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Toggled)
            {
                Back.Fill = On;
                Toggled = true;
                Dot.Margin = RightSide;
                click = true;
                SaveText();
            }
            else
            {

                Back.Fill = Off;
                Toggled = false;
                Dot.Margin = LeftSide;
                click = false;
            }

        }

        private void Dot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Toggled)
            {
                Back.Fill = On;
                Toggled = true;
                Dot.Margin = RightSide;
                click = true;
                SaveText();
            }
            else
            {

                Back.Fill = Off;
                Toggled = false;
                Dot.Margin = LeftSide;
                click = false;
                
            }

        }

        public OpenFileDialog Open { get; set; } = new OpenFileDialog();
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SaveText();
            Open.ShowDialog();
            Filename = Open.FileName;
            txtBlock.Text = Filename;
            txtBox.Text = File.ReadAllText(Filename);

        }

        public void SaveText()
        {
            if (txtBox.Text != string.Empty && click == true)
            {
                File.WriteAllText(Open.FileName, txtBox.Text);
            }
        }
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text != string.Empty)
            {
                File.WriteAllText(Open.FileName, txtBox.Text);
                MessageBox.Show("Text was Saved");
            }
            else
            {
                MessageBox.Show("Please open file");
            }
        }

        public string Text { set; get; } = string.Empty;
        private void CutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBlock.Text != string.Empty)
            {
                txtBox.Background = Brushes.White;
                txtBox.Foreground = Brushes.Black;
                Text = txtBox.Text;
                txtBox.Text = string.Empty;
                SaveText();
            }
            else
            {
                MessageBox.Show("There is no text");
            }
        }

        
        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBlock.Text != string.Empty)
            {
                txtBox.Background = Brushes.White;
                txtBox.Foreground = Brushes.Black;
                Text = txtBox.Text;
                SaveText();
            }
            else
            {
                MessageBox.Show("There is no text");
            }
        }

        private void PasteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBlock.Text != string.Empty && Text!=string.Empty) 
            {
                txtBox.Background = Brushes.White;
                txtBox.Foreground = Brushes.Black;
                txtBox.Text += Text;
                SaveText();
                Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please copy or cut ");
            }
        }

        private void SelectAllBtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text != string.Empty && txtBlock.Text != string.Empty)
            {
                txtBox.Background = Brushes.Blue;
                txtBox.Foreground = Brushes.White;
                SaveText();
            }
            else
            {
                MessageBox.Show("There is no text");
            }
        }
    }
}
