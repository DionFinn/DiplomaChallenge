namespace Classes 
{
    public class Product 
    {
        public string ProdID { get; set; }
        public int CatID { get; set; }
        public string Description { get; set; }
        public int UnitPrice { get; set; }
    }
}
    // ProdID NVARCHAR(100),
    // CatID int,
    // [Description] NVARCHAR(500),
    // UnitPrice int 
    // PRIMARY KEY (ProdID),
    // FOREIGN KEY (CatID) REFERENCES Category