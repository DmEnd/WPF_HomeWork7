﻿using Microsoft.Win32;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Top = Properties.Settings.Default.Position.Top;
            this.Left = Properties.Settings.Default.Position.Left;
            this.Height = Properties.Settings.Default.Position.Height;
            this.Width = Properties.Settings.Default.Position.Width;
        }
        //События
        //Сохранение положения
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Position = this.RestoreBounds;
            Properties.Settings.Default.Save();
        }
        //Смена стиля текста
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        //Изменение высоты текста 
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (textBox != null)
            {
                textBox.FontSize = fontSize;
            }
        }

        //Жирный текст 
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight != FontWeights.Bold)
            {
                textBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        //Наклон текста
        private void ToggleButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        //Подчеркивание текста
        private void ToggleButton_Click_2(object sender, RoutedEventArgs e)
        {

            if (textBox.TextDecorations.Count == 0)
            {
                textBox.TextDecorations.Add(TextDecorations.Underline);
            }
            else
            {
                textBox.TextDecorations.RemoveAt(0);
            }
        }

        //Чёрный текст
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        //Красный текст
        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;

            }
        }

        //Открытие приложения
        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        textBox.Text=File.ReadAllText(openFileDialog.FileName);
        //    }
        //}

        //Сохранение приложения
        //private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter= "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        //    if (saveFileDialog.ShowDialog()==true)
        //    {
        //        File.WriteAllText(saveFileDialog.FileName, textBox.Text);
        //    }
        //}

        //Закрытие приложения
        //private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        //Методы команд
        //Открытие приложения
        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        //Сохранение приложения
        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        //Закрытие приложения
        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
