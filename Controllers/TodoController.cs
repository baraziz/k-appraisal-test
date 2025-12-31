using KAppraisal.Dto;
using KAppraisal.Services;
using Microsoft.AspNetCore.Mvc;

namespace KAppraisal.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ApiResponse<TodoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(uint id, [FromBody] UpdateTodoRequest request)
        {
            Console.WriteLine(request.Status);
            TodoResponse? todoResponse = await _todoService.UpdateTodoAsync(id, request);
            if (todoResponse == null)
            {
                return NotFound(new ApiResponse<object>(
                    404,
                    "todo tidak ditemukan",
                    null
                ));
            }

            return Ok(new ApiResponse<TodoResponse>(
                200,
                "Todo berhasil diupdate",
                todoResponse
            ));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<TodoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Detele(uint id)
        {
            bool todoResponse = await _todoService.DeleteTodoAsync(id);
            if (todoResponse == false)
            {
                return NotFound(new ApiResponse<object>(
                    404,
                    "todo tidak ditemukan",
                    null
                ));
            }

            return Ok(new ApiResponse<object>(
                200,
                "Todo berhasil dihapus",
                null
            ));
        }


    }
}