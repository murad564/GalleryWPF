using Microsoft.Win32;
using Source.Models;
using Source.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.IO;
using Path = System.IO.Path;

namespace Source.Views;

public partial class MainWindow : Window
{

    public ObservableCollection<ImageCl> Images { get; set; } = new();
    public double width { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        for (int i = 0; i < FakeRepository.images.Count; i++)
        {
            Images.Add(FakeRepository.images[i]);
        }
        for (int i = 0; i < Images.Count; i++)
        {
            itms.Items.Add(Images[i]);
        }
        width = itms.Width;
    }

    private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is Label lb)
        {
            var source = lb.Tag;
            foreach (ImageCl image in Images)
            {
                if (source.ToString().Contains(Path.GetFileName(image.ImageUrl)))
                {
                    WatchImages watchImages = new WatchImages(image, Images);
                    watchImages.ShowDialog();
                }
            }
        }
    }



    private void MenuItem_Click_1(object sender, RoutedEventArgs e)
    {
        if (sender is MenuItem mi)
        {
            switch (mi.Header)
            {
                case "Save":
                    MessageBox.Show("Saved Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case "New":
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();

                    if (openFileDialog1.ShowDialog() == true)
                    {

                        Images.Add(new ImageCl()
                        {
                            ImageUrl = openFileDialog1.FileName,
                        });
                        itms.Items.Add(new ImageCl()
                        {
                            ImageUrl = openFileDialog1.FileName,
                        });
                    }
                    break;
                default:
                    break;
            }
        }


    }

    private void DropFileSP_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            ImageCl newimg = new()
            {
                ImageUrl = files[0],
                ImageName = "Name"
            };
            Images.Add(newimg);
            itms.Items.Add(newimg);
        }
    }
}