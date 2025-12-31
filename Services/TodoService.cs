using KAppraisal.Data;
using KAppraisal.Dto;
using KAppraisal.Enums;
using KAppraisal.Models;
using Microsoft.EntityFrameworkCore;

namespace KAppraisal.Services
{
    public class TodoService
    {
        private readonly AppDbContext _context;
        private readonly ProjectService _projectService;

        public TodoService(AppDbContext context, ProjectService projectService)
        {
            _context = context;
            _projectService = projectService;
        }

        public async Task<ProjectWithTodosResponse?> GetAllTodosAsync(uint projectId)
        {
            ProjectResponse? project = await _projectService.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                return null;
            }

            List<TodoResponse> todoResponses = await _context.Todos
                .AsNoTracking()
                .Where(t => t.ProjectId == project.Id)
                .Select(
                    t => new TodoResponse
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Description = t.Description,
                        Status = t.Status.ToString(),
                        UpdateAt = t.UpdateAt,
                        CreateAt = t.CreateAt
                    }
                )
                .ToListAsync();

            ProjectWithTodosResponse projectWithTodos = new()
            {
                Id = project.Id,
                Name = project.Name,
                CreateAt = project.CreateAt,
                Todos = todoResponses
            };


            return projectWithTodos;
        }

        public async Task<TodoResponse?> CreateProjectTodoAsync(uint projectId, CreateTodoRequest request)
        {
            ProjectResponse? project = await _projectService.GetProjectByIdAsync(projectId);

            if (project == null)
            {
                return null;
            }

            Todo todo = new()
            {
                Name = request.Name,
                Description = request.Description,
                ProjectId = project.Id
            };

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return new()
            {
                Id = todo.Id,
                Name = todo.Name,
                Description = todo.Description,
                Status = todo.Status.ToString(),
                UpdateAt = todo.UpdateAt,
                CreateAt = todo.CreateAt
            };
        }
        public async Task<TodoResponse?> UpdateTodoAsync(uint id, UpdateTodoRequest request)
        {
            Todo? todo = await _context.Todos
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (todo == null)
            {
                return null;
            }

            todo.Name = request.Name ?? todo.Name;
            todo.Description = request.Description ?? todo.Description;
            if (request.Status != null)
            {
                if (Enum.TryParse<TodoStatus>(request.Status, true, out var status))
                {
                    todo.Status = status;
                }
            }
            todo.UpdateAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new()
            {
                Id = todo.Id,
                Name = todo.Name,
                Description = todo.Description,
                Status = todo.Status.ToString(),
                UpdateAt = todo.UpdateAt,
                CreateAt = todo.CreateAt
            };
        }

        public async Task<bool> DeleteTodoAsync(uint id)
        {
            Todo? todo = await _context.Todos
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();
            if (todo == null)
            {
                return false;
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return true;
        }



    }
}