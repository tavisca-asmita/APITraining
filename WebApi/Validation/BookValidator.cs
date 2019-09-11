using System.Text.RegularExpressions;
using WebApi.Model;
using FluentValidation;

namespace WebApi.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Id).NotEmpty().WithMessage("Id Cannot Be Empty").GreaterThan(0).WithMessage("Id Must Be Positive");
            RuleFor(book => book.Price).NotEmpty().WithMessage("Price Cannot Be Empty").GreaterThan(0).WithMessage("Price Must Be Positive");
            RuleFor(book => book.Name).NotNull().WithMessage("Name Cannot Be Null").Must(ContainsOnlyLetters).WithMessage("Name Must Not Contain Digits");
            RuleFor(book => book.Author).NotNull().WithMessage("Author Cannot Be Null").Must(ContainsOnlyLetters).WithMessage("Author Must Not Contain Digits");
            RuleFor(book => book.Category).NotNull().WithMessage("Category Cannot Be Null").Must(ContainsOnlyLetters).WithMessage("Category Must Not Contain Digits");
        }
                
        private bool ContainsOnlyLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z ]+$");
        }
    }

    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(id => id).NotEmpty().WithMessage("Id Cannot Be Empty").GreaterThan(0).WithMessage("Id Must Be Positive");
        }
    }
}
