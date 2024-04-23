namespace BankBranchesMiniProject.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double civilID { get; set; }

        public string Position { get; set; }

        public BankBranch Workplace { get; set; }
    }

    //public class Workplace { 
    
    //    public List<Employee> Employees { get; set;}
    //}
}
