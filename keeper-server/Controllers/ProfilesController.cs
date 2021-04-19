using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeper_server.Models;
using keeper_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keeper_server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _service;
    private readonly VaultsService _vserv;
    private readonly KeepsService _kserv;

    public ProfilesController(ProfilesService service, VaultsService vserv, KeepsService kserv)
    {
      _service = service;
      _vserv = vserv;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _service.GetProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/vaults")]
    public ActionResult<IEnumerable<VaultKeepViewModel>> GetVaultByProfileId(string id)
    {
      try
      {
        return Ok(_vserv.GetByProfileId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<VaultKeepViewModel>> GetKeepByProfileId(string id)
    {
      try
      {
        return Ok(_kserv.GetByProfileId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}