using EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.IRepository
{
    public interface IRole
    {
        IEnumerable<Role> Roles();
        Role Role(int ID);
        bool Update(int ID, Role role);
        bool Delete(int ID);
        bool Post(Role role);
    }
}
