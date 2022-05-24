namespace SanaWebTest.Storage.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
