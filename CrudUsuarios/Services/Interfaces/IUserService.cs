using CrudUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsuarios.Services.Interfaces
{
    public interface IUserService
    {
        User Create(User user);
        User FindById(int id);
        List<User> FindAll();
        User Update(User user, int id);
        bool Delete(int id);
    }
}
