using System.Globalization;

namespace PointOfSale;
public class Price {
    public Price(decimal amount) => Amount = amount;

    public decimal Amount { get; }

    public override string ToString() => $"${Amount.ToString("0.00", CultureInfo.InvariantCulture)}";
}
