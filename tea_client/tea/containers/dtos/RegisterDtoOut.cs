using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea.containers.dtos
{
    class RegisterDtoOut
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }

        public RegisterDtoOut(string username, string password, string name, string phoneNumber)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }
    }
}
