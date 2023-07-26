namespace SinafApi.Models
{

    public class Pix
    {
        public Pix() { }
       
        public int Id { get; set; }
        public string? NomeCliente { get; set; }

        public double Valor { get; set; }

        public string? QRCode { get; set; } 

    }
}