using DemoAppWeb_Session.BLL.Interfaces;
using DemoAppWeb_Session.BLL.Models;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAppWeb_Session.BLL.Services
{
    public class MemberService : IMemberService
    {
        // ↓ Fake Data. Don't do this in real project (╯°□°）╯︵ ┻━┻
        private static List<Member> _Members = new List<Member>
        {
            new Member
            {
                MemberId = 1,
                Username = "Della",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$dTBKOU1LcWw5UUxLdUN0aQ$nhBktHfOTNPjxOjKuE9BRA",
                Firstname = "Della",
                Lastname = "Duck"
            },
             new Member
            {
                MemberId = 2,
                Username = "Zaza42",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Zaza",
                Lastname = "Vanderquack"
            }
        };
        private static int _NextId = 3;

        public Member? Login(string username, string password)
        {
            Member? target = _Members.SingleOrDefault(m => m.Username == username);

            if (target == null)
            {
                return null; // Or Throw Exception
            }

            bool isValid = Argon2.Verify(target.HashPwd, password);

            if (!isValid)
            {
                return null; // Or Throw Exception
            }

            return target;
        }

        public Member? Register(string username, string password, string firstname, string lastname)
        {
            if (_Members.Any(m => m.Username == username))
            {
                return null; // Or Throw Exception
            }

            Member memberToAdd = new Member
            {
                MemberId = _NextId,
                Username = username,
                HashPwd = Argon2.Hash(password),
                Firstname = firstname,
                Lastname = lastname
            };

            _Members.Add(memberToAdd);
            _NextId++;

            return memberToAdd;
        }
    }
}
