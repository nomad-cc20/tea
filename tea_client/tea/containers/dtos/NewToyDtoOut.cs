using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea.containers.dtos
{
    class NewToyDtoOut
    {
        public string name { get; set; }
        public string username { get; set; }

        public NewToyDtoOut(string name, string username)
        {
            this.name = name;
            this.username = username;
        }
    }
}
