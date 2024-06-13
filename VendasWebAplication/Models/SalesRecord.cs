using VendasWebAplication.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace VendasWebAplication.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }

        [Display(Name = "Vendedor")]
        //Aqui estou falando que cada SalesRecord tem 1 vendedor
        public Seller Seller { get; set; }

        //Aqui estou criando um construtor vazio,é preciso criar pois terei construtor com argumentos
        public SalesRecord()
        {

        }
        //Aqui estou criando um construtor com argumentos
        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
