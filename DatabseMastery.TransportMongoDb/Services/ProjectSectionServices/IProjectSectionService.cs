using DatabseMastery.TransportMongoDb.Dtos.ProjectSectionDtos;

namespace DatabseMastery.TransportMongoDb.Services.ProjectSectionServices
{
    public interface IProjectSectionService
    {
         Task <List<ResultProjectSectionDto>> GetAllProjectSectionAsync();
        Task CreateProjectSectionAsync(CreateProjectSectionDto createProjectSectionDto);
        Task UpdateProjectSectionAsync(UpdateProjectSectionDto updateProjectSectionDto);
        Task DeleteProjectSectionAsync(string id);
        Task <GetProjectSectionByIdDto> GetProjectSectionByIdAsync(string id);
    }
}
