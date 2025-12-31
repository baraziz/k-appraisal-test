using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAppraisal.Models
{
    [Table("projects")]
    public class Project
    {

        [Key]
        public uint Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        public List<Todo> Todos { get; } = new List<Todo>();
    }
}