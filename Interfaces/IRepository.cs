namespace SinafApi.Models
{
    public interface IRepository
    {
        void CreateData<T>(T entity) where T : class;
        void UpdateData<T>(T entity) where T : class;
        void DeleteData<T>(T entity) where T : class;
        Task<bool> SaveDataAsynch();

        // Meios de Pagamento
        Task<MeioPagamento[]> GetAllMeioPagAsynch();
        Task<MeioPagamento> GetMeioPagAsynchById(int meiopagId);

        // Boleto
        Task<Boleto[]> GetAllBoletoAsynch();
        Task<Boleto> GetBoletoAsynchById(int boletoId);

        // Pix
        Task<Pix[]> GetAllPixAsynch();
        Task<Pix> GetPixAsynchById(int pixId);
    }
}