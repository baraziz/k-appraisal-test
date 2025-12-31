namespace KAppraisal.Dto
{
    public class TodoResponse
    {
        public uint Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = null!;

        public DateTime UpdateAt { get; set; }

        public DateTime CreateAt { get; set; }
    }
}