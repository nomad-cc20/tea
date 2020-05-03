using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea
{
    class Offer
    {
        public long ID { get; }
        public List<Toy> Toys { get; }
        public User User { get; }
        public bool IsActive { get; set; }
        private readonly List<Bid> bids;
        public Bid Winner { get; set; }

        public Offer(long id, User user)
        {
            this.ID = id;
            this.User = user;
            this.IsActive = true;
            this.Winner = null;
        }

        public Offer(long iD, List<Toy> toys, User user, bool isActive, List<Bid> bids, Bid winner)
        {
            ID = iD;
            Toys = toys;
            User = user;
            IsActive = isActive;
            this.bids = bids;
            Winner = winner;
        }

        public void Bid(Bid newBid)
        {
            this.bids.Add(newBid);
        }

        public List<Bid> ListBids()
        {
            return this.bids;
        }

        public void Accept(Bid winnerBid)
        {
            if (bids.Contains(winnerBid)) {
                this.IsActive = false;
                this.Winner = winnerBid;
            }
            else
                throw new ArgumentException("Illegal bid!");
        }

        public override bool Equals(object obj)
        {
            return obj is Offer && ((Offer)obj).ID == this.ID;
        }

        public override int GetHashCode()
        {
            return (int)(base.GetHashCode() * (this.ID % Int32.MaxValue)) % Int32.MaxValue;
        }

        public override string ToString()
        {
            // TODO abandoned
            return "Active:\t" + (IsActive ? "yes" : "no")
                + (IsActive ? "" : Environment.NewLine + "Winner:\t" + this.Winner);
        }
    }
}
