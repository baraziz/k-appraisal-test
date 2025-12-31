using KAppraisal.Dto;
using KAppraisal.Services;
using Microsoft.AspNetCore.Mvc;

namespace KAppraisal.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {

        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<ProjectResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Index()
        {
            List<ProjectResponse> projects = await _projectService.GetAllProjectAsync();
            return Ok(new ApiResponse<List<ProjectResponse>>(
                200,
                "Berhasil menampilkan semua projek",
                projects
            ));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ProjectResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Store([FromBody] CreateProjectRequest request)
        {
            ProjectResponse projectResponse = await _projectService.CreateProjectAsync(request);
            return Created("", new ApiResponse<ProjectResponse>(
                200,
                "Projek berhasil dibuat",
                projectResponse
            ));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ProjectResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProjectById(uint id)
        {
            ProjectResponse? project = await _projectService.GetProjectByIdAsync(id);

            if (project == null)
            {
                return NotFound(new ApiResponse<object>(
                    404,
                    "Projek tidak ditemukan",
                    null
                ));
            }

            return Ok(new ApiResponse<ProjectResponse>(
                200,
                "Projek ditemukan",
                project
            ));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ApiResponse<ProjectResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProjectById(uint id, [FromBody] UpdateProjectRequest request)
        {
            ProjectResponse? project = await _projectService.UpdateProjectByIdAsync(id, request);

            if (project == null)
            {
                return NotFound(new ApiResponse<object>(
                    404,
                    "Projek tidak ditemukan",
                    null
                ));
            }

            return Ok(new ApiResponse<ProjectResponse>(
                200,
                "Projek berhasil di update",
                project
            ));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProjectById(uint id)
        {

            bool result = await _projectService.DeleteProjectByIdAsync(id);

            if (result == false)
            {
                return NotFound(new ApiResponse<object>(
                    404,
                    "Projek tidak ditemukan",
                    false
                ));
            }

            return Ok(
                new ApiResponse<object>(
                    200,
                    "Projek berhasil dihapus",
                    true
                )
            );

        }


    }
}