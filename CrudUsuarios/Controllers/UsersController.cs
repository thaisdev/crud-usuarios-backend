using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudUsuarios.Context;
using CrudUsuarios.Models;
using CrudUsuarios.Services;
using System.Net;
using CrudUsuarios.Services.Interfaces;
using CrudUsuarios.ViewModel;

namespace CrudUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CrudUserContext _context;
        private readonly IUserService _service;

        public UsersController(CrudUserContext context, IUserService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            try
            {
               var resp = _service.FindAll();
               return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { errorMessage = ex.Message });
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = _service.FindById(id);
                if (user != null)
                {
                    return Ok(user);
                } else
                {
                    return NotFound(new { errorMessage = "Nenhum usuário encontrado" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { errorMessage = ex.Message });
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserViewModel userViewModel)
        {
            try
            {
                var resp = _service.Update(userViewModel, id);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { errorMessage = ex.Message });
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserViewModel userViewModel)
        {
            try
            {
                var resp = _service.Create(userViewModel);
                return StatusCode((int)HttpStatusCode.Created, resp);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { errorMessage = ex.Message });
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var resp = _service.Delete(id);
                return Ok(new { message = "Usuário deletado com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { errorMessage = ex.Message });
            }
        }
    }
}
