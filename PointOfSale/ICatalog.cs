namespace PointOfSale;
public interface ICatalog {
    Product FindProductByCode(string code);
}
