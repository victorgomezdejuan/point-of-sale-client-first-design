namespace PointOfSale;

public class Product {
    public Product(string code, Price price) {
        Code = code;
        Price = price;
    }

    public string Code { get; }
    public Price Price { get; }
}