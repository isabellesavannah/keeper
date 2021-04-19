using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keeper_server.Models;
using keeper_server.Services;

namespace keeper_server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _service;

    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<string>> CreateAsync([FromBody] VaultKeep newVk)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVk.CreatorId = userInfo.Id;
        return Ok(_service.Create(newVk));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteAsync(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _service.Delete(id);
        return Ok("Deleted");

      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}