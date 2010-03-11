using System;
using System.Collections.Generic;

namespace Domain
{
    public class Group
    {
        public long ID
        { get; private set; }

        //public IDictionary<User, bool> Users
        //{ get; private set; }
    }

    public class User
    {
        public long ID
        { get; private set; }

        public IDictionary<Group, bool> Groups
        { get; private set; }

        public User()
        {
            Groups = new Dictionary<Group, bool>();
        }
    }


}