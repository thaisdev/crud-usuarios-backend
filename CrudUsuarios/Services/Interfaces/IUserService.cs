using CrudUsuarios.Models;
using CrudUsuarios.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsuarios.Services.Interfaces
{
    public interface IUserService
    {
        User Create(UserViewModel userViewModel);
        User FindById(int id);
        List<User> FindAll();
        User Update(UserViewModel userViewModel, int id);
        bool Delete(int id);
    }
}
