using System;
using keeper_server.Models;
using keeper_server.Repositories;

namespace keeper_server.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    internal VaultKeep Create(VaultKeep newVk)
    {
      //TODO if they are creating a wishlistproduct, make sure they are the creator of the list
      return _repo.Create(newVk);

    }

    internal void Delete(int id)
    {
      //NOTE getbyid to validate its valid and you are the creator
      _repo.Delete(id);
    }
  }
}
