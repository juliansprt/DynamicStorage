using System.ComponentModel.DataAnnotations;

namespace SanaWebTest.Storage.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
