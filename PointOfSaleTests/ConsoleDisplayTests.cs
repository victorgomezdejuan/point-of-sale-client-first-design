using PointOfSale;

namespace PointOfSaleTests;
public class ConsoleDisplayTests {
    [Fact]
    public void DisplayPrice() {
        // Arrange
        var newOut = new StringWriter();
        Console.SetOut(newOut);
        var display = new ConsoleDisplay();
        var price = new Price(77.55M);

        // Act
        display.DisplayPrice(price);

        // Assert
        Assert.Equal("Price: $77.55", newOut.ToString().Trim());

        // Cleanup
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
}
