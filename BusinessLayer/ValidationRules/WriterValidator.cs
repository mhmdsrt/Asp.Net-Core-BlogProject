using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator :AbstractValidator<Writer> // Validator -> Doğrulayıcı , Validation -> Doğrulama, Rule -> Kural, Fluent -> Sürekli,akıcı
	{
		// Empty -> Boş, yoksun
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Boş geçilemez").MinimumLength(3).WithMessage("Minumum 3 karakter girin.").
				MaximumLength(40).WithMessage("Maksimum 40 karakter girin."); 

			RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Boş geçilemez").MinimumLength(10).WithMessage("Minumum 10 karakter girin.").
				MaximumLength(1000).WithMessage("Maksimum 1000 karakter girin.");


			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Boş geçilemez");


			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Boş geçilemez").MinimumLength(4).WithMessage("Minumum 4 karakter girin.").
				MaximumLength(20).WithMessage("Maksimum 20 karakter girin.");

		}
	}
}
