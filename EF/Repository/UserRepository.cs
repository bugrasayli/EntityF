using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.IRepository;
using EF.Model;

namespace EF.Repository
{
    public class UserRepository : IUser
    {
        UserContext ctx;
        public UserRepository()
        {
            ctx = new UserContext();
        }
        public bool Delete(int ID)
        {
            User a = this.ctx.User.Where(x => x.ID == ID).FirstOrDefault();
            int b = 0;
            if (a == null)
                return false;
            else
            {
                this.ctx.User.Remove(a);
                b = ctx.SaveChanges();
            }
            if (b == 1)
                return true;
            else
                return false;
        }
        public bool Post(User user)
        {
            ctx.User.Add(user);
            int a = ctx.SaveChanges();
            if (a == 1)
                return true;
            else return false;
        }
        public bool Update(User _user, int ID)
        {
            User user = ctx.User.Where(x => x.ID == ID).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            user.Name = _user.Name;
            user.Surname = _user.Surname;
            user.RoleID = _user.RoleID;
            int a = ctx.SaveChanges();
            if (a == 0)
                return false;
            return true;
        }
        public User user(int ID)
        {
            var B = ctx.User.FirstOrDefault(x=> x.ID ==ID);
            var C = B.Role;



            var A = (from user in ctx.User
                     join role in ctx.Role on user.RoleID equals role.ID
                     where user.ID == ID 
                     select new User { ID =0 , Name=user.Name,Surname= user.Surname,Role= role })
                     .FirstOrDefault();
            return A;
        }
        public Task<List<User>> users()
        {
            return Task.FromResult(this.ctx.User.ToList());
        }
    }
}
