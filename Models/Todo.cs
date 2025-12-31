using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAppraisal.Enums;

namespace KAppraisal.Models
{
    [Table("todos")]
    public class Todo
    {

        [Key]
        public uint Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [Required]
        public TodoStatus Status { get; set; } = TodoStatus.Todo;

        [Column("update_at")]
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [Column("project_id")]
        public uint ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; } = null!;
    }
}