
     public class Building
    {
        private decimal cashflow;
        public int Price { get; set; }
        public string Type { get; set; }
        public int Rooms { get; set; }
        public decimal Cashflow{
            get{ return cashflow;}
            set{cashflow = value;}
        }
        public string Location{ get;set;}
         
         
        public Building(int Price,string Type,int Rooms,decimal Cashflow,string Location){
            this.Price = Price;
            this.Type=Type;
            this.Rooms = Rooms;
            this.Cashflow = Cashflow;
            this.Location = Location;
        }
    }
