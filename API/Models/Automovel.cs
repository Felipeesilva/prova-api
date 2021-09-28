using System;

namespace API.Models
{
    public class Automovel
    {
        public Automovel() => CriadoEm = DateTime.Now;
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; } 
        public DateTime CriadoEm { get; set; }

        public override string ToString() =>
            $"Marca: {Marca} | Modelo: {Modelo} | Cor: {Cor} | Combustivel: {Combustivel} | Criado Em: {CriadoEm} ";
        
    }
}