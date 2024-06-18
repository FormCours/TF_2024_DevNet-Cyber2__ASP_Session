using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppWeb_Session.BLL.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Username { get; set; }
        public string HashPwd { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
