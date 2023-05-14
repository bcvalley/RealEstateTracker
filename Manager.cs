
    public class Manager
    {
        public string? Name { get; set; }
        public int Experience { get; set; }
        public int Years { get; set; }
        public decimal Salary { get; set; }
        public Manager(string Name,int Years,int Experience,decimal Salary)
        {
            this.Name = Name;
            this.Years = Years;
            this.Experience = Experience;
            this.Salary = Salary;
        }
    }
