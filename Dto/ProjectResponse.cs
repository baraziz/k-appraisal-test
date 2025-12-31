using System.Text.Json.Serialization;

namespace KAppraisal.Dto
{
    public class ProjectResponse
    {

        public uint Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreateAt { get; set; }

    }
}