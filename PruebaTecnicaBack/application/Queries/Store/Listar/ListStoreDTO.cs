
namespace PruebaTecnicaBack.Application.Commands.Store.Listar
{
    public class ListStoreDTO
    {
        public List<ListStoreItemDTO> Stores { get; set; } = new List<ListStoreItemDTO>();
    }

    public class ListStoreItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BannerUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public double DistanceInKm { get; set; }  // Opcional, si quieres calcular distancia
        public bool IsOpen { get; set; }          // Opcional, si quieres calcular estado abierto
    }
}