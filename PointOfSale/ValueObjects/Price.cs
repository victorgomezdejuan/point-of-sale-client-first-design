using System.Globalization;

namespace PointOfSale.ValueObjects;
public class Price {
    private Price(decimal amount) => Amount = amount;

    public decimal Amount { get; }

    public static Price FromDecimal(decimal amount) => new(amount);

    public override string ToString() => $"${Amount.ToString("0.00", CultureInfo.InvariantCulture)}";
}
