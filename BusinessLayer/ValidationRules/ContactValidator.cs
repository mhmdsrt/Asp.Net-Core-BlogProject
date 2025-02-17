using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator:AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			RuleFor(x => x.ContactUserName).NotEmpty().WithMessage("Boş geçilemez").MaximumLength(30).WithMessage("Makisumum 30 Karakter").MinimumLength(10)
				 .WithMessage("Minumum 10 Karakter");

			RuleFor(x=>x.ContactUserMail).NotEmpty().WithMessage("Boş geçilemez").MaximumLength(40).WithMessage("Makisumum 40 Karakter").MinimumLength(10)
				 .WithMessage("Minumum 10 Karakter");

			RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Boş geçilemez").MaximumLength(50).WithMessage("Makisumum 50 Karakter").MinimumLength(5)
				 .WithMessage("Minumum 5 Karakter");

			RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Boş geçilemez").MaximumLength(400).WithMessage("Makisumum 400 Karakter").MinimumLength(10)
				 .WithMessage("Minumum 10 Karakter");


		}
	}
}
