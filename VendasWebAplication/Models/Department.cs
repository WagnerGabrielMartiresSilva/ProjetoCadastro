using System;
using System.Collections.Generic;

namespace VendasWebAplication.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //Aqui estou criando um construtor vazio,é preciso criar pois terei construtor com argumentos
        public Department()
        {

        }

        //Aqui criei um construtor com argumentos
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            //Para cada vendedor Seller na minha lista chamo o totalsales do vendedor,
            //no periodo inicial e final e faço uma soma para todos os vendedores do meu departamento
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
