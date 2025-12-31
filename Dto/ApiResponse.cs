namespace KAppraisal.Dto
{
    public class ApiResponse<T>(ushort status, string message, T? data)
    {
        public ushort Status { get; set; } = status;

        public string Message { get; set; } = message;

        public T? Data { get; set; } = data;
    }
}