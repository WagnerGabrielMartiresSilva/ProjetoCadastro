using VendasWebAplication.Models.Enums;
using System;

namespace VendasWebAplication.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }

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
