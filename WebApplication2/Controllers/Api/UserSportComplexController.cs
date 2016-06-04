using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using Core.Interfaces;
using Infrastructure;
using WebApplication2.Models;

namespace WebApplication2.Controllers.Api
{
    public class UserSportComplexController : ApiController
    {
        private readonly IUserRepository userRepository;

        public UserSportComplexController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("api/userSportComplex/")]
        public IHttpActionResult GetUsersSportComplex()
        {
            var users = userRepository.GetAll().AsQueryable().Include(u=>u.SportComplex);

            return Ok(users.Select(u => new UserSportComplexVM
            {
                Name = u.Name, Id = u.Id, SportComplexName = u.SportComplex== null? "": u.SportComplex.Name
            }).ToList());
        }

       [HttpGet]
        [Route("api/userSportComplex/{id}")]
        public IHttpActionResult GetUsersSportComplex(int id)
        {
            var user = userRepository.GetAll().AsQueryable().Include(u=>u.SportComplex).SingleOrDefault(x => x.Id == id);
            if (user == null) return NotFound();

            return Ok(new UserSportComplexVM
            {
                Name = user.Name, Id = user.Id, SportComplexName = user.SportComplex== null? "": user.SportComplex.Name
            });
        }

        [HttpPost]
        [Route("api/userSportComplex/{id}")]
        public IHttpActionResult EditUserSportComplex(int id, UserSportComplexVM newSC)
        {
            var user = userRepository.GetAll().AsQueryable().Include(u=>u.SportComplex).SingleOrDefault(x => x.Id == id);
            if (user == null) return NotFound();

            user.SportComplex.Name = newSC.SportComplexName;

            userRepository.Update(user);

            userRepository.Commit();

            return Ok();
        } 
    }
}
