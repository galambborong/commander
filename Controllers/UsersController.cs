using System;
using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public UsersController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var userItems = _repository.GetAllUsers();
            return Ok(userItems);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if (userItem == null)
            {
                return NotFound();
            }

            return Ok(userItem);
        }
    }
}