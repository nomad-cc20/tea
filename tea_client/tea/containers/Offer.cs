using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea
{
    class Offer
    {
        public int ID { get; }
        public Bid Subject { get; }
        public bool IsActive { get; set; }
        private List<Bid> bids;
        public Bid Winner { get; set; }

        public Offer(int id, Bid subject)
        {
            this.ID = id;
            this.Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            this.IsActive = true;
            this.Winner = null;
        }

        public Offer(int iD, Bid subject, bool isActive, List<Bid> bids, Bid winner) : this(iD, subject)
        {
            this.IsActive = isActive;
            this.bids = bids;
            this.Winner = winner;
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
    }
}
