using BookLibrary.Entities;
using FluentValidation;

namespace BookLibrary.Servise
{
    public class LibraryValidator: AbstractValidator<LibrariesEntities>
    {
        public LibraryValidator()
        { 
            RuleFor(lib => lib.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Length(2,100).WithMessage("Length ({TotalLength}) of {PropertyName} is invalid")
                .Must(BeAValidName);
        }
        private bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetterOrDigit);
        }
    }
}
