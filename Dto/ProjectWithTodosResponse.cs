namespace KAppraisal.Dto
{
    public class ProjectWithTodosResponse
    {
        public uint Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreateAt { get; set; }
        public List<TodoResponse> Todos { get; set; } = [];

    }
}