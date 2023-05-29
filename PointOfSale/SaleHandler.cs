namespace PointOfSale;
public class SaleHandler {
    private ICatalog catalog;
    private IDisplay display;

    public SaleHandler(ICatalog catalog, IDisplay display) {
        this.catalog = catalog;
        this.display = display;
    }

    public void OnBarcode(string barcode) {
        if (barcode == "")
            display.DisplayEmptyCode();
        else {
            Product? product = catalog.FindProductByCode(barcode);
            DisplayProductInfo(barcode, product);
        }
    }

    private void DisplayProductInfo(string barcode, Product? product) {
        if (product is null)
            display.DisplayProductNotFound(barcode);
        else
            display.DisplayPrice(product.Price);
    }
}
