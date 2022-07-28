using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FriendZone.Models;
using FriendZone.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly SubscribersService _subscribersService;

        public AccountController(AccountService accountService, SubscribersService subscribersService)
        {
            _accountService = accountService;
            _subscribersService = subscribersService;
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("subscribers")]
        [Authorize]
        public async Task<ActionResult<List<SubscriberProfileViewModel>>> GetMySubscribers()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_subscribersService.GetByAccountId(userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/subscribers")]
        public ActionResult<List<SubscriberProfileViewModel>> GetSubscribers(int id)
        {
            try
            {
                List<SubscriberProfileViewModel> subscribers = _subscribersService.GetBySubscriberId(id);
                return Ok(subscribers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Account>> Create([FromBody] Account accountData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                accountData.CreatorId = userInfo.Id;
                accountData.Creator = userInfo;
                Account account = _accountService.Create(accountData);
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }


}