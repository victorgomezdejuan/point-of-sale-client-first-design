using Moq;
using PointOfSale;

namespace PointOfSaleTests;

public class SaleHandlerTests {
    [Fact]
    public void ItemFound() {
        // Arrange
        var productToBeFound = new Product("12345", new Price(77.55M));

        var catalogMock = new Mock<ICatalog>();
        catalogMock.Setup(c => c.FindProductByCode(productToBeFound.Code)).Returns(productToBeFound);

        var displayMock = new Mock<IDisplay>();

        var saleHandler = new SaleHandler(catalogMock.Object, displayMock.Object);

        // Act
        saleHandler.OnBarcode(productToBeFound.Code);

        // Assert
        catalogMock.Verify(d => d.FindProductByCode(productToBeFound.Code));
        displayMock.Verify(d => d.DisplayPrice(productToBeFound.Price));
    }

    [Fact]
    public void ItemNotFound() {
        // Arrange
        var productToBeFound = new Product("11111", new Price(11.22M));

        var catalogMock = new Mock<ICatalog>();
        catalogMock.Setup(c => c.FindProductByCode(productToBeFound.Code)).Returns((Product)null);

        var displayMock = new Mock<IDisplay>();

        var saleHandler = new SaleHandler(catalogMock.Object, displayMock.Object);

        // Act
        saleHandler.OnBarcode(productToBeFound.Code);

        // Assert
        catalogMock.Verify(d => d.FindProductByCode(productToBeFound.Code));
        displayMock.Verify(d => d.DisplayProductNotFound(productToBeFound.Code));
    }

    [Fact]
    public void EmptyBarcode() {
        // Arrange
        var catalogMock = new Mock<ICatalog>();
        var displayMock = new Mock<IDisplay>();

        var saleHandler = new SaleHandler(catalogMock.Object, displayMock.Object);

        // Act
        saleHandler.OnBarcode("");

        // Assert
        catalogMock.Verify(d => d.FindProductByCode(""), Times.Never);
        displayMock.Verify(d => d.DisplayProductNotFound(""), Times.Never);
        displayMock.Verify(d => d.DisplayPrice(It.IsAny<Price>()), Times.Never);
        displayMock.Verify(d => d.DisplayEmptyCode());
    }
}