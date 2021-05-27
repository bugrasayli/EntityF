using EF.IRepository;
using EF.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRole role;
        public RoleController(IRole role)
        {
            this.role = role;
        }

        [HttpGet]
        public ActionResult<List<Role>> Get()
        {
            return Ok(this.role.Roles().ToList());
        }
        [HttpGet("{ID}")]
        public ActionResult<Role> Get(int ID)
        {
            return Ok(this.role.Role(ID));
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] Role role)
        {
            return Ok(this.role.Post(role));
        }

        [HttpPut("{ID}")]
        public ActionResult<bool> Put(int ID,[FromBody]Role role)
        {
            return Ok(this.role.Update(ID,role));
        }

        [HttpDelete("{ID}")]
        public ActionResult<bool> Delete(int ID)
        {
            return Ok(this.role.Delete(ID));
        }
    }
}
