namespace Classes 
{
    public class Order
    {
        public Product Prod { get; set; }
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public int Quantity { get; set; }
        public string CustID { get; set; }
        public string ShipMode { get; set; }

        public float Total(int Quantity, float price)
        {
            return Quantity * (int)price;
        }

        public float GST(int Quantity, float price)
        {
            return Total(Quantity, price) / 10;
        }
    }
}
// CustID, ProdID, OrderDate, Quantity, ShipDate, ShipMode