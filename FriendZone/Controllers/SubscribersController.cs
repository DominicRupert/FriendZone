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
                subscriberData.SubscribedId = userInfo.Id;
                return Ok(_subscribersService.Create(subscriberData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]

        public ActionResult<Subscriber> GetAsync(int id)
        {
            try
            {
                Subscriber subscriber = _subscribersService.Get(id);
                return Ok(_subscribersService.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    
       
    }
}