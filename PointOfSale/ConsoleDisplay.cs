namespace PointOfSale;
public class ConsoleDisplay : IDisplay {
    public void DisplayPrice(Price price) => Console.WriteLine($"Price: {price}");

    public void DisplayProductNotFound(string code) => throw new NotImplementedException();

    public void DisplayEmptyCode() => throw new NotImplementedException();
}
