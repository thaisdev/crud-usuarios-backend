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
            _context.User.Add(user);
            var resp = _context.SaveChanges();
            if (resp == 1)
            {
                return user;
            }
            else
            {
                throw new Exception("Ocorreu um erro desconhecido ao salvar o usuário");
            }
        }

        public bool Delete(int id)
        {
            var foundedUser = _context.User.Where(user => user.Id == id).FirstOrDefault();
            if (foundedUser != null)
            {
                _context.User.Remove(foundedUser);
                var resp = _context.SaveChanges();
                if (resp == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Ocorreu um erro desconhecido ao deletar o usuário");
                }
            }
            else
            {
                throw new Exception("Usuário não encontrado");
            }
        }

        public List<User> FindAll()
        {
            return _context.User.ToList();
        }

        public User FindById(int id)
        {
            return _context.User.Where(user => user.Id == id).FirstOrDefault();
        }

        public User Update(User user, int id)
        {
            var foundedUser = _context.User.Where(user => user.Id == id).FirstOrDefault();
            if (foundedUser != null)
            {
                foundedUser.Name = user.Name;
                foundedUser.LastName = user.LastName;
                foundedUser.Birthday = user.Birthday;
                foundedUser.Escolaridade = user.Escolaridade;
                var resp = _context.SaveChanges();
                if (resp == 1)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Ocorreu um erro desconhecido ao alterar o usuário");
                }
            } else
            {
                throw new Exception("Usuário não encontrado");
            }
        }
    }
}
