using PointOfSale;

namespace PointOfSaleTests;
public class CatalogTests {
    [Fact]
    public void ProductFound() {
        // Arrange
        var productToBeFound = new Product("12345", new Price(77.55M));

        var catalog = new InMemoryCatalog(new List<Product> { productToBeFound });

        // Act
        var foundProduct = catalog.FindProductByCode(productToBeFound.Code);

        // Assert
        Assert.Equal(productToBeFound, foundProduct);
    }

    [Fact]
    public void ProductNotFound() {
        // Arrange
        var catalog = new InMemoryCatalog(new List<Product>());

        // Act
        var foundProduct = catalog.FindProductByCode("54321");

        // Assert
        Assert.Null(foundProduct);
    }
}
