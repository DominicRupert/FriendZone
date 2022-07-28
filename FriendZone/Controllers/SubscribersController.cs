using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FriendZone.Models;
using FriendZone.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;

namespace FriendZone.Controllers
{
    [Route("api/[controller]")]
    public class SubscribersController : ControllerBase
    {
        private readonly SubscribersService _subscribersService;

        public SubscribersController(SubscribersService subscribersService)
        {
            _subscribersService = subscribersService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Subscriber>> CreateAsync([FromBody] Subscriber subscriberData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                subscriberData.AccountId = userInfo.Id;
                return Ok(_subscribersService.Create(subscriberData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Subscriber>> DeleteAsync(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _subscribersService.Delete(id, userInfo.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    
       
    }
}