using System;
using System.Collections.Generic;

namespace Domain
{

    public interface IAggregateRoot
    {

    }

    public enum DefaultRoleNames
    {
        Role1,
        Role2,
        Role3
    }

    public class Role : IAggregateRoot
    {
        public virtual int Id { get; private set; }
        public virtual DefaultRoleNames Name { get; set; }
        public virtual IList<Privilege> Privileges { get; set; }

        private string _typeOfContent;

        public virtual Type TypeOfContent
        {
            get { return Type.GetType(_typeOfContent); }
            set { _typeOfContent = value.FullName; }
        }

        public Role()
        {
            Privileges = new List<Privilege>();
        }

        public virtual void AddPrivilege(Privilege privilege)
        {
            privilege.RolesWithThisPrivilege.Add(this);
            Privileges.Add(privilege);
        }
    }

    public class Privilege : IAggregateRoot
    {
        public virtual int Id { get; private set; }
        public virtual string Path { get; set; }
        public virtual IList<Role> RolesWithThisPrivilege
        {
            get;
            private set;
        }

        public Privilege()
        {
            RolesWithThisPrivilege = new List<Role>();
        }
    }
}