using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using keeper_server.Models;
using keeper_server.Services;

namespace keeper_server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  // REVIEW[epic=Authentication] this tag enforces the user must be logged in
  [Authorize]
  public class AccountController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly KeepsService _kserv;
    private readonly VaultsService _vserv;

    public AccountController(ProfilesService ps, KeepsService kserv, VaultsService vserv)
    {
      _ps = ps;
      _kserv = kserv;
      _vserv = vserv;
    }

    [HttpGet]
    // REVIEW[epic=Authentication] async calls must return a System.Threading.Tasks, this is equivalent to a promise in JS
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        // REVIEW[epic=Authentication] how to get the user info from the request token
        // same as to req.userInfo
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("keeps")]
    public async Task<ActionResult<IEnumerable<Keep>>> GetKeepsByAccountId()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_kserv.GetKeepsByAccountId(userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("vaults")]
    public async Task<ActionResult<IEnumerable<Vault>>> GetVaultssByAccountId()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vserv.GetVaultssByAccountId(userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}