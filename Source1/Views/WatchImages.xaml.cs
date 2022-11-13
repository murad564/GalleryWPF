using Microsoft.Win32;
using Source.Models;
using Source.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Source.Views
{
    public partial class WatchImages : Window
    {
        public ObservableCollection<ImageCl> Images { get; set; } = new();
        bool isAutoPlayActice = false;



        public ImageCl Selected
        {
            get { return (ImageCl)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }

        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof(ImageCl), typeof(WatchImages));

        public WatchImages(ImageCl slc, ObservableCollection<ImageCl> imageList)
        {
            InitializeComponent();
            DataContext = this;
            for (int i = 0; i < imageList.Count; i++)
            {
                Images.Add(imageList[i]);
            }
            Selected = slc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            if (sender is Button btn)
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    if (Images[i].ImageUrl == Selected.ImageUrl)
                    {
                        index = i;
                        break;
                    }
                }
                switch (btn.Name)
                {
                    case "next":
                        index++;
                        break;
                    case "prev":
                        index--;
                        break;
                    default:
                        break;
                }
                try
                {

                    if (index < 0)
                        Selected = Images[Images.Count - 1];
                    else if (index == Images.Count)
                        Selected = Images[0];
                    else Selected = Images[index];
                }
                catch (Exception)
                {

                    MessageBox.Show("There is no more image", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
        CancellationTokenSource _tokenSource = null;

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            int index = 0;
            if (sender is Button btn)
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    if (Images[i].ImageUrl == Selected.ImageUrl)
                    {
                        index = i;
                        break;
                    }
                }
            }
            for (int i = index; i < Images.Count; i++)
            {
                Selected = Images[i];
                Images[i] = Selected;
                await Task.Delay(1000);
                if (_tokenSource.IsCancellationRequested)
                {
                    try
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    catch (Exception)
                    {
                        return;
                    }

                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _tokenSource.Cancel();

        }
    }
}