using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea.containers.dtos
{
    class BidDtoIn
    {
        public long Id { get; set; }
        public long OfferId { get; set; }
        public string NameOfPerson { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<Toy> Toys { get; set; }
    }
}
