using MediatR;
using PruebaTecnicaBack.application.repositories;
using PruebaTecnicaBack.domain.entities;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PruebaTecnicaBack.Application.Commands.Store.Listar
{
    public class ListStoreQueryHandler : IRequestHandler<ListStoreQuery, ListStoreDTO>
    {
        private readonly IStoreRepository _storeRepository;

        public ListStoreQueryHandler(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<ListStoreDTO> Handle(ListStoreQuery request, CancellationToken cancellationToken)
        {
            var allStores = await _storeRepository.GetAllAsync(); // Obtener todas las tiendas

            var dto = new ListStoreDTO
            {
                Stores = allStores.Select(store => new ListStoreItemDTO
                {
                    Id = store.Id,
                    Name = store.Name,
                    BannerUrl = store.BannerUrl,
                    Latitude = store.Latitude,
                    Longitude = store.Longitude,
                    OpenTime = DateTime.Today.Add(store.OpenTime).ToString("hh:mm tt", CultureInfo.InvariantCulture),
                    CloseTime = DateTime.Today.Add(store.CloseTime).ToString("hh:mm tt", CultureInfo.InvariantCulture),
                    IsOpen = DateTime.Now.TimeOfDay >= store.OpenTime && DateTime.Now.TimeOfDay <= store.CloseTime,
                    DistanceInKm = 0 // Opcional: calcular según la ubicación del usuario
                }).ToList()
            };

            return dto;
        }
    }
}
