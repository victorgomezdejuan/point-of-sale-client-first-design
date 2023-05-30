using PointOfSale.ValueObjects;

namespace PointOfSale;
public class InMemoryCatalog {
    private Dictionary<string, Product> productCatalog;

    public InMemoryCatalog(List<Product> products) {
        productCatalog = products.ToDictionary(p => p.Code);
    }

    public Product? FindProductByCode(string code) {
        if (productCatalog.TryGetValue(code, out var product)) {
            return product;
        }

        return null;
    }
}
