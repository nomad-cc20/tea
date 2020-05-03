using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea
{
    class User
    {
        public long ID { get; }
        public string Username { get; }
        public string Password { get; }

        private readonly List<Offer> offers;
        private readonly List<Offer> biddedOffers;

        public User(long id, string username, string password)
        {
            this.ID = id;
            this.Username = username ?? throw new ArgumentNullException(nameof(username));
            this.Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public User(int iD, string username, string password, List<Offer> offers, List<Offer> bids) : this(iD, username, password)
        {
            this.offers = offers;
            this.biddedOffers = bids;
        }

        public void AddOffer(Offer newOffer)
        {
            this.offers.Add(newOffer);
        }

        public List<Offer> ListOffers()
        {
            return this.offers;
        }

        public void AddBiddedOffer(Offer newBiddedOffer)
        {
            this.biddedOffers.Add(newBiddedOffer);
        }

        public List<Offer> ListBiddedOffers()
        {
            return this.biddedOffers;
        }

        public override bool Equals(object obj)
        {
            return obj is User && ((User)obj).ID == this.ID;
        }

        public override int GetHashCode()
        {
            return (int)(base.GetHashCode() * (this.ID % Int32.MaxValue)) % Int32.MaxValue;
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
