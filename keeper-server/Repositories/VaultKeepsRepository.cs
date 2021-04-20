using System;
using System.Data;
using keeper_server.Models;
using Dapper;

namespace keeper_server.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal VaultKeep Create(VaultKeep newVk)
    {
      string sql = @"
      INSERT INTO vaultkeeps 
      (vaultId, keepId, creatorId) 
      VALUES 
      (@VaultId, @KeepId, @CreatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newVk);
      newVk.Id = id;
      return newVk;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });

    }

    internal VaultKeepViewModel GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id;";
      return _db.QueryFirstOrDefault<VaultKeepViewModel>(sql, new { id });
    }
  }
}