

using BookLibrary.Entities;
using FluentValidation;

namespace BookLibrary.Servise
{
    public class BookValidator: AbstractValidator<BookEntities>
    {
        public BookValidator()
        { 
            RuleFor (book => book.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Length(2, 100).WithMessage("Length ({TotalLength}) of {PropertyName} is invalid")
                .Must(BeAValidName);
            RuleFor(book => book.Author)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Length(2, 100).WithMessage("Length ({TotalLength}) of {PropertyName} is invalid")
                .Must(BeAValidName);
            RuleFor(book => book.Year)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} can't be more then " + DateTime.Now.Year);
            RuleFor(book => book.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is empty")
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
