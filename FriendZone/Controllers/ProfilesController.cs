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
    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly SubscribersService _subscribersService;

        public ProfilesController(AccountService accountService, SubscribersService subscribersService)
        {
            _accountService = accountService;
            _subscribersService = subscribersService;
        }
       

        [HttpGet]

        public async Task<ActionResult<Profile>> GetProfiles()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                List<Profile> profiles = _accountService.GetProfiles();
                return Ok(profiles);
               
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/subscribers")]
        public ActionResult<Profile> GetSubscribers(string id)
        {
            try
            {
                List<SubscriberProfileViewModel> subscribers = _subscribersService.GetSubscribers(id);
                return Ok(subscribers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/subbed")]
        public ActionResult<Profile> GetSubbed(string id)
        {
            try
            {
                List<SubscriberProfileViewModel> subscribers = _subscribersService.GetSubbed(id);
                return Ok(subscribers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}