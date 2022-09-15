namespace Classes
{
    public class Customer
    {
        public string CustID { get; set; }
        public string FullName { get; set; }
        public int SegID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostCode { get; set; }
        public string Region { get; set; }
    }
    
}

    // CustID NVARCHAR(100),
    // FullName NVARCHAR(100),
    // SegID int,
    // Country NVARCHAR(100),
    // City NVARCHAR(100),
    // [State] NVARCHAR(100),
    // PostCode int,
    // Region NVARCHAR(100),
    // PRIMARY KEY (CustID),
    // FOREIGN KEY (SegID) REFERENCES Segment,
    // FOREIGN KEY (Region) REFERENCES Region 