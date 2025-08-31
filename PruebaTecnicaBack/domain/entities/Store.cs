using System;
using IDSLatam.Common.Core.Base;

namespace MiProyectoApi.Models
{
    public class Store:EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BannerUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }
}
