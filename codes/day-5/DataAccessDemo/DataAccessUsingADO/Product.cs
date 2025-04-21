namespace DataAccessUsingADO
{
    public class Product
    {
        //automatic or auto-implemented property
        public int Id { get; set; }

        //property setter
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string Make { get; set; } = string.Empty;

        public string Year { get; set; } = DateTime.Now.Year.ToString();

        public Product() { }

        public Product(int id, string name, decimal price, string? description, string make, string year)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Make = make;
            Year = year;
        }
    }
}
