using Source.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Repository;

public class FakeRepository
{
    public static List<ImageCl> images = new()
    {
        new ImageCl() { ImageUrl = "/StaticFiles/Images/img1.jpg" },
        new ImageCl() { ImageUrl = "/StaticFiles/Images/img2.jpg" },
        new ImageCl() { ImageUrl = "/StaticFiles/Images/img3.jpg" },
        new ImageCl() { ImageUrl = "/StaticFiles/Images/img4.jpg" },
        new ImageCl() { ImageUrl = "/StaticFiles/Images/img5.jpg" },
        new ImageCl() { ImageUrl = "/StaticFiles/Images/img6.jpg" },
        new ImageCl() { ImageUrl = "/StaticFiles/Images/img7.jpg" },
        new ImageCl() { ImageUrl = "/StaticFiles/Images/img8.jpg" }
    };
}