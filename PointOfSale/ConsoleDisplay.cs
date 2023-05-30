using PointOfSale.Interfaces;
using PointOfSale.ValueObjects;

namespace PointOfSale;
public class ConsoleDisplay : IDisplay {
    public void DisplayPrice(Price price) => Console.WriteLine($"Price: {price}");

    public void DisplayProductNotFound(string code) => Console.WriteLine($"Product not found: {code}");

    public void DisplayEmptyCode() => Console.WriteLine("Empty barcode");
}
