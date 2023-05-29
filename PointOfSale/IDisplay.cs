namespace PointOfSale;
public interface IDisplay {
    void DisplayPrice(Price price);

    void DisplayProductNotFound(string code);

    void DisplayEmptyCode();
}
