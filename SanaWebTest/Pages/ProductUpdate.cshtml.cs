using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.Repository;

namespace SanaWebTest.Pages
{
    public class ProductUpdateModel : PageModel
    { 
        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public Product CurrentProduct { get; set; }

        public List<Category> Categories { get; set; }

        public async Task OnGetAsync([FromServices] IRepository<Product> productRepository, [FromServices] IRepository<Category> categoryRepository, int id)
        {
            ProductId = id;
            CurrentProduct = await productRepository.GetAsync(ProductId);
            Categories = (await categoryRepository.GetAllAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync([FromServices] IRepository<Product> productRepository)
        {
            await productRepository.UpdateAsync(CurrentProduct);

            return RedirectToPage("/Index");
        }
    }
}
