using AadAuthApi.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AadAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly FriendContext context;

        [HttpGet]
        [RequiredScope("read")]
        public IActionResult GetAllFriends()
        {
            return Ok(context.Friends);
        }

        //[HttpPost]
        //[RequiredScope("write")]
        //public async Task<IActionResult> AddFriend([FromBody] Friend friend)
        //{
        //    await context.Add(friend);
        //    return StatusCode((int)HttpStatusCode.Created);
        //}

        [HttpDelete("{aadId}")]
        [RequiredScope("write")]
        public async Task<IActionResult> RemoveFriend(string aadId)
        {
            //await context.Remove(aadId);
            return NoContent();
        }

        [HttpPost("clear")]
        public async Task<IActionResult> ClearFriends()
        {
            //await context.Database.();
            return NoContent();
        }
    }
}
