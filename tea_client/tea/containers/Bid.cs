using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea
{
    class Bid
    {
        public int ID { get; }
        public string Caption { get; }
        public List<Object> toys { get; }
        public bool IsActive { get; set; }
        public string Description { get; }
        public User User { get; }

        public Bid(int id, string caption, string description, User user)
        {
            this.ID = id;
            this.Caption = caption ?? throw new ArgumentNullException(nameof(caption));
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public override bool Equals(object obj)
        {
            return obj is Bid && ((Bid)obj).ID == this.ID;
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() * this.ID) % Int32.MaxValue;
        }

        public override string ToString()
        {
            return "Caption:\t" + this.Caption + Environment.NewLine
                + "Description:\t" + this.Description + Environment.NewLine
                + "Owner:\t" + this.User;
        }
    }
}
