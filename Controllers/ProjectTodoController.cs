
using KAppraisal.Dto;
using KAppraisal.Services;
using Microsoft.AspNetCore.Mvc;

namespace KAppraisal.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/todos")]
    public class ProjectTodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public ProjectTodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<ProjectWithTodosResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Index(uint projectId)
        {
            ProjectWithTodosResponse? projectWithTodos = await _todoService.GetAllTodosAsync(projectId);
            if (projectWithTodos == null)
            {
                return NotFound(new ApiResponse<object>(
                    404,
                    "projek tidak ditemukan",
                    null
                ));
            }

            return Ok(new ApiResponse<ProjectWithTodosResponse>(
                200,
                "Todo berhasil didapat",
                projectWithTodos
            ));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<TodoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Store(uint projectId, [FromBody] CreateTodoRequest request)
        {
            TodoResponse? todoResponse = await _todoService.CreateProjectTodoAsync(projectId, request);
            if (todoResponse == null)
            {
                return NotFound(new ApiResponse<object>(
                    404,
                    "projek tidak ditemukan",
                    null
                ));
            }

            return Ok(new ApiResponse<TodoResponse>(
                200,
                "Todo berhasil ditambahkan",
                todoResponse
            ));
        }
    }
}