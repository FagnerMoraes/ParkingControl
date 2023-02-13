﻿using ParkingControl.Domain.Entities;

namespace ParkingControl.Domain.Repositories;
public interface IParkingSpotRepository
{
    Task<int?> CreateAsync(ParkingSpot parkingSpot);
    Task<ParkingSpot?> GetByLicensePlateAsync(string licensePlate);
    Task UpdateAsync(ParkingSpot parkingSpot);

}
