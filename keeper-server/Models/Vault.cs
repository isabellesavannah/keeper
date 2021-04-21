using System.ComponentModel.DataAnnotations;
using keeper_server.Models;

namespace keeper_server
{
    public class Vault
    {
        public int Id {get; set;}
        public string CreatorId {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public bool IsPrivate {get; set;}
        public Profile Creator {get; set;}
    }

    
}