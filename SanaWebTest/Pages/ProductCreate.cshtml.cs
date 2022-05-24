using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.Repository;

namespace SanaWebTest.Pages
{
    public class ProductCreateModel : PageModel
    {
        [BindProperty]
        public Product CurrentProduct { get; set; }


        public List<Category> Categories { get; set; }

        public async Task OnGetAsync([FromServices]IRepository<Category> categoryRepository)
        {
            CurrentProduct = new Product();
            Categories = (await categoryRepository.GetAllAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync([FromServices]IRepository<Product> productRepository)
        {
            await productRepository.InsertAsync(CurrentProduct);
            return RedirectToPage("/Index");
        }


    }
}
