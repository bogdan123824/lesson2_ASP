namespace WebApplication2
{
    public class WeatherForecast
    {
        //public DateOnly Date { get; set; }

        //public int TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //public string? Summary { get; set; }

        public string text { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
    }

    public class Manufacturer
    {
        public string Name { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public int CategoryIdx { get; set; }
        public int ManufacturerIdx { get; set; }
        public decimal Price { get; set; }
    }

    public class Provider
    {
        public string Name { get; set; }
    }
}
