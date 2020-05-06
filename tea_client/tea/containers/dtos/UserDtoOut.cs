using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea.containers.dtos
{
    class UserDtoOut
    {
        public string username { get; set; }
        public string password { get; set; }

        public UserDtoOut(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
