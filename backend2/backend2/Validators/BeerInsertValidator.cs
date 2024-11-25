using backend2.DTOs;
using FluentValidation;

namespace backend2.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {

        public BeerInsertValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must is contained");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe ser entre 2 a 20 caracteres");

            RuleFor(x => x.BrandID).NotNull().WithMessage("La marca es obligatoria ");
            RuleFor(x => x.BrandID).GreaterThan(0).WithMessage("Error con el valor enviado de la marca ");


        }

    }
}
