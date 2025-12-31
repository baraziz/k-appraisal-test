using System.ComponentModel.DataAnnotations;
using KAppraisal.Enums;
using KAppraisal.Rules;

namespace KAppraisal.Dto
{
    public class UpdateTodoRequest
    {
        [MinLength(1)]

        public string? Name { get; set; }

        [MinLength(1)]
        public string? Description { get; set; }

        [TodoStatusValidation]
        public string? Status { get; set; }
    }
}