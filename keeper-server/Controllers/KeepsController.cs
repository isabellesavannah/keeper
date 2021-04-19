using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using keeper_server.Models;
using keeper_server.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keeper_server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _service;
    public KeepsController(KeepsService ps)
    {
      _service = ps;
    }

    [HttpGet]
    public ActionResult<Keep> Get()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]  // NOTE '{}' signifies a var parameter
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    // NOTE ANYTIME you need to use Async/Await you will return a Task
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
      try
      {
        // NOTE HttpContext == 'req'
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newKeep.CreatorId = userInfo.Id;
        newKeep.Creator = userInfo;
        return Ok(_service.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> Edit([FromBody] Keep updated, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updated.CreatorId = userInfo.Id;
        updated.Creator = userInfo;
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}