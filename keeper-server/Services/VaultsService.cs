using System;
using System.Collections.Generic;
using System.Linq;
using keeper_server.Models;
using keeper_server.Repositories;

namespace keeper_server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Vault> GetAll()
    {
      return _repo.GetAll();
    }

    internal Vault GetById(int id, string userId)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      else if (data.CreatorId != userId & data.IsPrivate)
      {
        throw new Exception("Not authorized!");
      }
      return data;
    }

    internal IEnumerable<Vault> GetByProfileId(string id)
    {
      IEnumerable<Vault> vaults = _repo.GetVaultByProfileId(id);
      // return vaults.ToList().FindAll(p => p.Public);
      return _repo.GetVaultByProfileId(id);
    }

    internal IEnumerable<Vault> GetByAccountId(string id)
    {
      return _repo.GetVaultByProfileId(id);
    }

    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal Vault Edit(Vault updated)
    {
      var original = GetById(updated.Id, updated.CreatorId);
      if (original.CreatorId != updated.CreatorId)
      {
        throw new Exception("Invalid Edit Permissions");
      }
      updated.Name = updated.Name != null ? updated.Name : original.Name;
      updated.Description = updated.Description != null ? updated.Description : original.Description;
      return _repo.Edit(updated);
    }


    internal string Delete(int id, string userId)
    {
      var original = GetById(id, userId);
      if (original.CreatorId != userId)
      {
        throw new Exception("Invalid Delete Permissions");
      }
      _repo.Delete(id);
      return "delorted";
    }
  }
}