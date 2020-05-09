using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;

namespace tea.containers.dtos
{
    class ToyDtoIn
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageData { get; set; }

        public ToyDtoIn() { }

        public ToyDtoIn(Toy toy)
        {
            Id = toy.ID;
            Name = toy.Name;
            ImageData = toy.ImageData;
        }
    }
}
