using System.ComponentModel.DataAnnotations;
using KAppraisal.Enums;

namespace KAppraisal.Dto
{
    public class CreateTodoRequest
    {

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

    }
}