using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Model;

namespace EF.IRepository
{
    public interface IUser
    {
        Task<List<User>> users();
        User user(int ID);
        bool Delete(int ID);
        bool Update(User user,int ID);
        bool Post(User user);
    }
}
