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
        public string Description { get; }
        public User User { get; }

        public Bid(string caption, string description, User user)
        {
            this.ID = ID;
            this.Caption = caption ?? throw new ArgumentNullException(nameof(caption));
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
