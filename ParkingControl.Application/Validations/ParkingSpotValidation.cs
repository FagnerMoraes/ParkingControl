using FluentValidation;
using ParkingControl.Application.DTOs.Request;

namespace ParkingControl.Application.Validations;
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
