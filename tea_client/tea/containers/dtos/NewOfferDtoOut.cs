using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea.containers.dtos
{
    class NewOfferDtoOut
    {
        public String caption { get; set; }
        public String description { get; set; }
        public List<Toy> toys { get; set; }
        public String username { get; set; }
    }
}
