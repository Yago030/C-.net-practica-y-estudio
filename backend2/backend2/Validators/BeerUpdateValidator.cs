using backend2.DTOs;
using FluentValidation;

namespace backend2.Validators
{
    public class BeerUpdateValidator : AbstractValidator <BeerUpdateDto> //aca le pasmos sobre que contorlador trabajeremos
    {
        public BeerUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must is contained");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe ser entre 2 a 20 caracteres");

            RuleFor(x => x.BrandId).NotNull().WithMessage("La marca es obligatoria ");
            //RuleFor(x => x.B).GreaterThan(0).WithMessage("Error con el valor enviado de la marca ");

        }
    }
}
