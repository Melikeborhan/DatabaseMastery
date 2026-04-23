using DatabseMastery.TransportMongoDb.Dtos.ProjectSectionDtos;
using DatabseMastery.TransportMongoDb.Services.ProjectSectionServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Controllers
{
    public class ProjectSectionController : Controller
    {
        public readonly IProjectSectionService _projectSectionService;


        public ProjectSectionController(IProjectSectionService projectSectionService)
        {
            _projectSectionService = projectSectionService;
        }

        public async Task<IActionResult> ProjectSectionList()
        {
            var values = await _projectSectionService.GetAllProjectSectionAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProjectSection()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectSection(CreateProjectSectionDto createProjectSectionDto)
        {
            await _projectSectionService.CreateProjectSectionAsync(createProjectSectionDto);
            return RedirectToAction("ProjectSectionList");
        }

        public async Task<IActionResult> DeleteProjectSection(string id)
        {
            await _projectSectionService.DeleteProjectSectionAsync(id);
            return RedirectToAction("ProjectSectionList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProjectSection(string id)
        {
            var values = await _projectSectionService.GetProjectSectionByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProjectSection(UpdateProjectSectionDto updateProjectSectionDto)
        {
            await _projectSectionService.UpdateProjectSectionAsync(updateProjectSectionDto);
            return RedirectToAction("ProjectSectionList");
        }
    }
}
