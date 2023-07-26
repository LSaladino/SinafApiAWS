namespace SinafApi.Models
{

    public class MeioPagamento
    {
        public MeioPagamento() { }
       
        public int Id { get; set; }
        public string? NomeCliente { get; set; }

        public double Valor { get; set; }
        public string? LinhaDigitavel { get; set; }

        public string? QRCode { get; set; } 
        public string? TipoPagamento { get; set; }
        public string? Processado { get; set; }

    }
}