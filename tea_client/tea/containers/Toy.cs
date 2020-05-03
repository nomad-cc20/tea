using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace tea
{
    class Toy
    {
        public long ID { get; }
        public String Name { get; }
        public Image Image { get; }

        public Toy(long id, string name, Image image)
        {
            this.ID = id;
            this.Name = name;
            this.Image = image;
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
