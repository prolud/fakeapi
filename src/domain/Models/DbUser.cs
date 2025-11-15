using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Models
{
    [Table("users")]
    public class DbUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        public required string Username { get; set; }
        [Column("password")]
        public required string Password { get; set; }
    }
}