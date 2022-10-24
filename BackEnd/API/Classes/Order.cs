namespace Classes 
{
    public static class Order
    {
        public Product Prod { get; set; }
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public int Quantity { get; set; }
        public string CustID { get; set; }
        public string ShipMode { get; set; }

        public float getTotal(int Quantity, float price)
        {
            return Quantity * (int)price;
        }

        public float getGST(int Quantity, float price)
        {
            return Total(Quantity, price) / 10;
        }
    }
}
// CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode