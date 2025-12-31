using System.ComponentModel.DataAnnotations;

namespace KAppraisal.Dto
{
    public class CreateProjectRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}