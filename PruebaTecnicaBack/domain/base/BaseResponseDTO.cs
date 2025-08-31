using System;
namespace PruebaTecnicaBack.domain.baseD
{
    public class BaseResponseDTO
    {
        public BaseResponseDTO()
        {
            Excepcion = string.Empty;
            Confirmacion = false;
            Mensaje = String.Empty;
        }

        public string Excepcion { get; set; }
        public string Mensaje { get; set; }
        public bool Confirmacion { get; set; }
    }
}