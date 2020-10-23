using CrudUsuarios.Context;
using CrudUsuarios.Models;
using CrudUsuarios.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsuarios.Services
{
    public class UserService : IUserService
    {
        private CrudUserContext _context;

        public UserService(CrudUserContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
