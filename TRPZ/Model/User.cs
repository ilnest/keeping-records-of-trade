using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ
{
    class User
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int AccessLevel { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(int id, string fname, string lname, int accessLevel, string login, string password)
        {
            ID = id;
            FName = fname;
            LName = lname;
            AccessLevel = accessLevel;
            Login = login;
            Password = password;
        }
    }
}
