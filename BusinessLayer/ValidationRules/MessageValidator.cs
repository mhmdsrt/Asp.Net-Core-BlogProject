using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Boş Geçilemez")
                .MaximumLength(130).WithMessage("Maksiumum 130 Karakter")
                .MinimumLength(3).WithMessage("Minumum 3 karakter");

			RuleFor(x => x.MessageDetails).NotEmpty().WithMessage("Boş Geçilemez")
				.MaximumLength(430).WithMessage("Maksiumum 430 Karakter")
				.MinimumLength(3).WithMessage("Minumum 3 karakter");
		}
    }
}
