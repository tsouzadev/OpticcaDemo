using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoAppWeb.Pages
{
    public class DeleteDepartmentIdeaModel : PageModel
    {
        public readonly InnovationRepository _repository;

        public DeleteDepartmentIdeaModel(InnovationRepository repository)
        {
            _repository = repository;
        }

        public DepartmentIdea DepartmentIdea { get; set; }

        public async Task OnGet(int id)
        {
            DepartmentIdea = await _repository.GetDepartmentIdeaAsync(id);
        }

        public IActionResult OnPost(int id)
        {
            _repository.DeleteDepartmentIdeaAsync(id).GetAwaiter().GetResult();

            return RedirectToPage("Index");
        }
    }
}
