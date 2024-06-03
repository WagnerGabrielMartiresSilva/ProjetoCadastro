namespace VendasWebAplication.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get;set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        //Aqui fizemos uma associação para muitos
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }
        
        //Sales não entra no construtor, pois é um collection 
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Criando uma operação para adicionar vendas na nossa lista de vendas
        public void AddSales(SalesRecord sr) 
        {
            Sales.Add(sr);
        }
        //Criando uma operação para Remover vendas na nossa lista de vendas
        public void Remove(SalesRecord sr) 
        {
            Sales.Remove(sr);
        }
        //Criando uma operação de Total de vendas com uma expressão lambda
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
