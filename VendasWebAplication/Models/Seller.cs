using System.ComponentModel.DataAnnotations;

namespace VendasWebAplication.Models
{
    public class Seller
    {
        public int Id { get; set; }
       
        [Display(Name = "Nome")]
        [Required(ErrorMessage ="{0} Obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="{0} size should be betwen {2} and and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
       
        //O DepartmentId esta referenciando uma chave estrangeira
        public int DepartmentId { get; set; }

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
