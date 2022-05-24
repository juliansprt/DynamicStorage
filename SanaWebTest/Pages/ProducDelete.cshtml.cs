using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.Repository;

namespace SanaWebTest.Pages
{
    public class ProducDeleteModel : PageModel
    {
        public Product CurrentProduct { get; set; }

        [BindProperty]
        public int ProductId { get; set; }


        public async Task OnGetAsync([FromServices]IRepository<Product> productRepository, int id)
        {
            CurrentProduct = await productRepository.GetAsync(id);
            ProductId = id;
        }
       

        public async Task<IActionResult> OnPostAsync([FromServices]IRepository<Product> productRepository)
        {
            await productRepository.DeleteAsync(ProductId);
            return RedirectToPage("./Index");
        }
    }
}
