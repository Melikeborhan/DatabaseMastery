using DatabseMastery.TransportMongoDb.Services.ProjectSectionServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabseMastery.TransportMongoDb.Views.ViewComponents.DefaultComponents
{
    public class _DefaultWhatWeHaveDoneComponentPartial: ViewComponent
    {
        public readonly IProjectSectionService _projectSectionService;


        public _DefaultWhatWeHaveDoneComponentPartial(IProjectSectionService projectSectionService)
        {
            _projectSectionService = projectSectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _projectSectionService.GetAllProjectSectionAsync();
            return View(values);
        }

    }
}
