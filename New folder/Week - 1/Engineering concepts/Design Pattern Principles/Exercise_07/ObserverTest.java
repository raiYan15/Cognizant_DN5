public class ObserverTest {

    public static void main(String[] args) {

        System.out.println("=== Observer Pattern - Stock Market System ===\n");

        StockMarket appleStock = new StockMarket("AAPL");
        Observer mobileUser = new MobileApp("StockTracker");
        Observer webUser1   = new WebApp("FinanceHub");
        Observer webUser2   = new WebApp("MarketWatch");
        appleStock.registerObserver(mobileUser);
        appleStock.registerObserver(webUser1);
        appleStock.registerObserver(webUser2);
        appleStock.setStockPrice(182.50);
        appleStock.setStockPrice(185.00);
        System.out.println();
        appleStock.deregisterObserver(webUser2);
        appleStock.setStockPrice(179.75);
    }
}
