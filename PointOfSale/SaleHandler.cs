namespace PointOfSale;
public class SaleHandler {
    private ICatalog catalog;
    private IDisplay display;

    public SaleHandler(ICatalog catalog, IDisplay display) {
        this.catalog = catalog;
        this.display = display;
    }

    public void OnBarcode(string barcode) {
        Product product = catalog.FindProductByCode(barcode);
        display.DisplayPrice(product.Price);
    }
}
