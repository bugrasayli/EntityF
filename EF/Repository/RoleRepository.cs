using EF.IRepository;
using EF.Model;
using System.Collections.Generic;
using System.Linq;

namespace EF.Repository
{
    public class RoleRepository : IRole
    {
        UserContext ctx;
        public RoleRepository()
        {
            ctx = new UserContext();
        }
        public bool Delete(int ID)
        {
            Role role = this.ctx.Role.Where(x => x.ID == ID).FirstOrDefault();
            int a;
            if (role == null)
                return false;
            else
            {
                this.ctx.Role.Remove(role);
                a = ctx.SaveChanges();
            }
            if (a == 1)
                return true;
            else return false;
        }

        public bool Post(Role role)
        {
            ctx.Role.Add(role);
            int a = ctx.SaveChanges();
            if (a != 1)
                return false;
            else return true;
        }

        public Role Role(int ID)
        {
            return this.ctx.Role.Where(x => x.ID == ID).FirstOrDefault();
        }
        public IEnumerable<Role> Roles()
        {
            return ctx.Role;
        }

        public bool Update(int ID, Role role)
        {
            var Role = ctx.Role.Where(x=> x.ID == ID).FirstOrDefault();
            if (Role == null)
                return false;
            Role.Name = role.Name;
            int a =ctx.SaveChanges();
            if (a == 0)
                return false;
            return true;
        }
    }
}
