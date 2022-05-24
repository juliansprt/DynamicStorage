using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SanaWebTest.Storage;
using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.InMemory;
using SanaWebTest.Storage.Repository;

namespace SanaWebTest.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Storage container to Set or Gets the Storage Types
        /// </summary>
        private readonly IStorageContainer _storageContainer;

        public Dictionary<string, string> Storages { get; set; }

        public List<Product> Products { get; set; }


        [BindProperty]
        public string CurrentStorage { get; set; }



        public IndexModel(ILogger<IndexModel> logger, IStorageContainer storageContainer)
        {
            _logger = logger;
            _storageContainer = storageContainer;
            CurrentStorage = _storageContainer.GetCurrent().FullName;
        }


        public async Task OnGetAsync([FromServices]IRepository<Product> productRepository)
        {
            await LoadDataAsync(productRepository);
        }


        public async Task<IActionResult> OnPostAsync()
        {
            _storageContainer.SetCurrent(CurrentStorage);
            await Task.CompletedTask;

            return RedirectToPage("./Index");
        }
        


        /// <summary>
        /// Load Storage Types and Products of Storage type
        /// </summary>
        /// <param name="productRepository"></param>
        /// <returns></returns>
        private async Task  LoadDataAsync(IRepository<Product> productRepository)
        {
            Storages = _storageContainer.GetStorages();
            Products = (await productRepository.GetAllAsync()).ToList();

        }
    }


}