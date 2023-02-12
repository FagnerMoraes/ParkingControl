using FluentValidation;
using ParkingControl.Application.Contexts.ParkingSpots.DTOs.Request;

namespace ParkingControl.Domain.Contexts.ParkingSpots.Validations;
public class ParkingSpotValidation : AbstractValidator<CreateParkingSpotRequest>
{
	public ParkingSpotValidation()
	{
		RuleFor(parkingSpot => parkingSpot.LicensePlate)
			.NotEmpty().WithMessage("placa nao pode ser vazia")
			.MinimumLength(7).WithMessage("placa deve possuir no minimo 7 digitos")
			.MaximumLength(7).WithMessage("placa deve possuir no maximo 7 digitos");
            
	}
}
