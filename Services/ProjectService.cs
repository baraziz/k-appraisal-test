using KAppraisal.Data;
using KAppraisal.Dto;
using KAppraisal.Models;
using Microsoft.EntityFrameworkCore;

namespace KAppraisal.Services
{
    public class ProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectResponse>> GetAllProjectAsync()
        {
            List<ProjectResponse> projects = await _context.Projects
                .AsNoTracking()
                .Select(p => new ProjectResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreateAt = p.CreateAt
                })
                .ToListAsync();

            return projects;
        }

        public async Task<ProjectResponse> CreateProjectAsync(CreateProjectRequest request)
        {
            Project project = new()
            {
                Name = request.Name
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                CreateAt = project.CreateAt
            };
        }

        public async Task<ProjectResponse?> GetProjectByIdAsync(uint id)
        {
            ProjectResponse? project = await _context.Projects
                .Where(p => p.Id == id)
                .Select(p => new ProjectResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreateAt = p.CreateAt
                }
                )
                .FirstOrDefaultAsync();

            return project;
        }

        public async Task<ProjectResponse?> UpdateProjectByIdAsync(uint id, UpdateProjectRequest request)
        {
            Project? project = await _context.Projects
           .Where(p => p.Id == id)
           .FirstOrDefaultAsync();

            if (project == null)
            {
                return null;
            }

            project.Name = request.Name;

            await _context.SaveChangesAsync();

            return new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                CreateAt = project.CreateAt
            };
        }

        public async Task<bool> DeleteProjectByIdAsync(uint id)
        {
            Project? project = await _context.Projects
           .Where(p => p.Id == id)
           .FirstOrDefaultAsync();

            if (project == null)
            {
                return false;
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}