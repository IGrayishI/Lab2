using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_2
{
    


internal class Member : Lab2.Member
    {
        public enum Membership
        {
            Gold = 15,
            Silver = 10,
            Bronze = 5,
            Non = 0
        }

        //Fields
        private Membership _level;

        //Constructor
        public Member(string name, string password, Membership level)
            : base(name, password)
        {
            _level = level;
        }

        //Properties
        public Membership Level { get { return _level; } set { _level = value; } }

        //Methods

    }
}
