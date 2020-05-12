using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tea.containers.dtos;
using tea.util;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace tea
{
    class Toy
    {
        public long ID { get; set; }
        public String Name { get; set; }
        public string ImageData { get; set; }
        public ImageSource Image { get; set; }

        public Toy()
        {
        }

        public Toy(long id, string name, string image)
        {
            this.ID = id;
            this.Name = name;
            this.ImageData = image;
        }

        public Toy(ToyDtoIn dto)
        {
            this.ID = dto.Id;
            this.Name = dto.Name;
            this.ImageData = dto.ImageData;
        }

        public async Task BuildImage()
        {
            this.Image = await Photo.FromBase64(this.ImageData);
        }

        public override bool Equals(object obj)
        {
            return obj is Toy && ((Toy)obj).ID == this.ID;
        }

        public override int GetHashCode()
        {
            return (int)(base.GetHashCode() * (this.ID % Int32.MaxValue)) % Int32.MaxValue;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
