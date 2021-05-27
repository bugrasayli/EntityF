using EF.IRepository;
using EF.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IUser user;
        public UserController(IUser _user)
        {
            this.user = _user;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var A = await user.users();
            return Ok(A);
        }
        [HttpGet("{ID}")]
        public async Task<ActionResult<Object>> Get(int ID)
        {
            var a =  user.user(ID); //neden await kabul etmiyor
            return  Ok(a);
        }
        [HttpPost]
        public ActionResult<bool> Post([FromBody] User user) { return this.user.Post(user); }
        [HttpPut("{ID}")]
        public ActionResult<bool> Put([FromBody] User user, int ID) { return this.user.Update(user, ID); }
        [HttpDelete("{ID}")]
        public ActionResult<bool> Delete(int ID) { return this.user.Delete(ID); }
    }
}
