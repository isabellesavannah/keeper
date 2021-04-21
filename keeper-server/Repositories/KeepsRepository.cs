using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using keeper_server.Models;
using Dapper;

namespace keeper_server.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
      SELECT 
      k.*,
      prof.*
      FROM keeps k
      JOIN profiles prof ON k.creatorId = prof.id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, splitOn: "id");
    }

    internal Keep GetById(int id)
    {
      string sql = @" 
      SELECT 
      k.*,
      prof.*
      FROM keeps k
      JOIN profiles prof ON k.creatorId = prof.id
      WHERE k.id = @id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps 
      (name, description, img, keeps, creatorId) 
      VALUES 
      (@Name, @Description, @Img, @Keeps, @creatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    internal Keep Edit(Keep updated)
    {
      string sql = @"
        UPDATE keeps
        SET
         Name = @Name,
         description = @Description
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Keep> GetKeepByProfileId(string id)
    {
      string sql = @"
      SELECT 
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id
      WHERE keep.creatorId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { id }, splitOn: "id");
    }
// FIXME
    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      string sql = @"SELECT 
      k.*,
      vk.id AS VaultKeepId,
      profile.*
      FROM vaultkeeps vk
      JOIN profiles profile ON vk.creatorId = profile.id
      JOIN keeps k ON k.id = vk.keepId
      WHERE vk.vaultId = @id;";
      return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { id }, splitOn: "id");
    }

    internal IEnumerable<Keep> GetByOwnerId(string id)
    {
      string sql = @"
      SELECT 
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id
      WHERE keep.creatorId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { id }, splitOn: "id");
    }
  }
}