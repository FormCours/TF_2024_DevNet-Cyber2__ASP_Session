using DemoAppWeb_Session.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppWeb_Session.BLL.Interfaces
{
    public interface IMemberService
    {
        Member? Login(string username, string password);
        Member? Register(string username, string password, string firstname, string lastname);
    }
}
