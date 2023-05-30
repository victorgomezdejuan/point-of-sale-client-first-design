using PointOfSale;

namespace PointOfSaleTests;
public class ConsoleDisplayTests {
    private readonly StringWriter newOut;
    private readonly ConsoleDisplay display;

    public ConsoleDisplayTests() {
        newOut = new StringWriter();
        Console.SetOut(newOut);
        display = new ConsoleDisplay();
    }

    [Fact]
    public void DisplayPrice() {
        // Arrange
        var price = Price.FromDecimal(77.55M);

        // Act
        display.DisplayPrice(price);

        // Assert
        Assert.Equal("Price: $77.55", newOut.ToString().Trim());
    }

    [Fact]
    public void DisplayProductNotFound() {
        // Act
        display.DisplayProductNotFound("12345");

        // Assert
        Assert.Equal("Product not found: 12345", newOut.ToString().Trim());
    }

    [Fact]
    public void DisplayEmptyCode() {
        // Act
        display.DisplayEmptyCode();

        // Assert
        Assert.Equal("Empty barcode", newOut.ToString().Trim());
    }

    internal void Dispose() {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        newOut.Dispose();
    }
}
