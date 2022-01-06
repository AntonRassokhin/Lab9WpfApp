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

namespace Lab8WpfApp_hw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> styles = new List<string>() { "Светлая тема", "Темная тема" };
            styleBox.ItemsSource = styles;
            styleBox.SelectionChanged += ThemeChanger;
            styleBox.SelectedIndex = 0;
        }

        private void ThemeChanger(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("LightTheme.xaml", UriKind.Relative);
            if (styleIndex == 1)
            {
                uri = new Uri("DarkTheme.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedItem as string;
            if (text != null)
                text.FontFamily = new FontFamily(fontName);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            object fontSize = (sender as ComboBox).SelectedItem as string;
            if (text != null)
                text.FontSize = Convert.ToDouble(fontSize);
        }

        bool isBold;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (text != null)
            {
                if (!isBold)
                    text.FontWeight = FontWeights.Bold;
                else
                    text.FontWeight = FontWeights.Normal;
                isBold = !isBold;
            }

        }

        bool isItalic;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isItalic)
                text.FontStyle = FontStyles.Italic;
            else
                text.FontStyle = FontStyles.Normal;
            isItalic = !isItalic;
        }

        bool isUnderline;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!isUnderline)
                text.TextDecorations = TextDecorations.Underline;
            else
                text.TextDecorations = null;
            isUnderline = !isUnderline;
        }

        private void BlackRadioButton_Click(object sender, RoutedEventArgs e)
        {
            text.Foreground = Brushes.Black;
        }

        private void GreenRadioButton_Click(object sender, RoutedEventArgs e)
        {
            text.Foreground = Brushes.Green;
        }

        private void RedRadioButton_Click(object sender, RoutedEventArgs e)
        {
            text.Foreground = Brushes.Red;
        }






        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Еще не разработано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (.txt)| *.txt|Все файлы(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                text.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (.txt)| *.txt|Все файлы(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, text.Text);
            }
        }
    }
}
