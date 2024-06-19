using DemoAppWeb_Session.BLL.Interfaces;
using DemoAppWeb_Session.BLL.Models;
using Isopoh.Cryptography.Argon2;

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
                Lastname = "Duck",
                Role = Role.Admin,
            },
             new Member
            {
                MemberId = 2,
                Username = "Zaza42",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Zaza",
                Lastname = "Vanderquack",
                Role = Role.User,
            }
             ,
             new Member
            {
                MemberId = 3,
                Username = "Ibrahim",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Ibrahim",
                Lastname = "Vanderquack",
                Role = Role.User,
            },
             new Member
            {
                MemberId = 4,
                Username = "Zachary",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Zachary",
                Lastname = "Vanderquack",
                Role = Role.User,
            }
             ,
             new Member
            {
                MemberId = 5,
                Username = "Olivier",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Olivier",
                Lastname = "Vanderquack",
                Role = Role.User,
            },
             new Member
            {
                MemberId = 6,
                Username = "Brian",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Brian",
                Lastname = "Vanderquack",
                Role = Role.User,
            },
             new Member
            {
                MemberId = 7,
                Username = "Julien",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Julien",
                Lastname = "Vanderquack",
                Role = Role.User,
            },
             new Member
            {
                MemberId = 8,
                Username = "Floriane",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Floriane",
                Lastname = "Vanderquack",
                Role = Role.User,
            },
             new Member
            {
                MemberId = 9,
                Username = "Eleftherios",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Eleftherios",
                Lastname = "Vanderquack",
                Role = Role.User,
            },
             new Member
            {
                MemberId = 10,
                Username = "Damien",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Damien",
                Lastname = "Vanderquack",
                Role = Role.User,
            },
             new Member
            {
                MemberId = 11,
                Username = "Tanya",
                HashPwd = "$argon2id$v=19$m=16,t=2,p=1$M0IyN0x4MnhLZ2tHYXBFeg$oPXMeYUFL7yXsqRJ88Z4GA",
                Firstname = "Tanya",
                Lastname = "Vanderquack",
                Role = Role.User,
            }
        };
        private static int _NextId = 12;

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
