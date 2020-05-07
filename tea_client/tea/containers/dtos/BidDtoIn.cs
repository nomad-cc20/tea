using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea.containers.dtos
{
    class BidDtoIn
    {
        public long offerId { get; set; }
        public string nameOfPerson { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public List<Toy> toys { get; set; }
    }
}
