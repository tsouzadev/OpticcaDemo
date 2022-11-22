using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        public readonly InnovationRepository _repository;

        public IndexModel(InnovationRepository repository)
        {
            _repository = repository;
        }

        public List<DepartmentIdea> DepartmentIdeas { get; set; }

        public DepartmentIdea DepartmentIdea { get; set; }

        public async Task OnGet()
        {
            this.DepartmentIdeas = await _repository.GetDepartmentIdeasAsync();

            this.DepartmentIdea = new DepartmentIdea();
        }

        public async Task OnPost(DepartmentIdea departmentIdea)
        {
            await _repository.SaveDepartmentIdeaAsync(departmentIdea);

            this.DepartmentIdeas = await _repository.GetDepartmentIdeasAsync();

            this.DepartmentIdea = new DepartmentIdea();
        }

        public async Task OnDelete(int id)
        {
            this.DepartmentIdeas = await _repository.GetDepartmentIdeasAsync();

            this.DepartmentIdea = new DepartmentIdea();

            return;
        }

        public async Task Delete(int id)
        {
            this.DepartmentIdeas = await _repository.GetDepartmentIdeasAsync();

            this.DepartmentIdea = new DepartmentIdea();

            return;
        }
    }
}