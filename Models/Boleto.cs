namespace SinafApi.Models
{

    public class Boleto
    {
        public Boleto() { }
       
        public int Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public double Valor { get; set; }
        public string? LinhaDigitavel { get; set; }
       
    }
}