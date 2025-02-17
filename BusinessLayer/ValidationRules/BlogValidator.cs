using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class BlogValidator : AbstractValidator<Blog>
	{

		public BlogValidator()
		{
			RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Boş Geçilemez").MinimumLength(3).WithMessage("Minumum 3 Karakter").
			MaximumLength(25).WithMessage("Maksimum 25 Karakter");

			RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Boş Geçilemez").MinimumLength(80).WithMessage("Minumum 80 Karakter").
			MaximumLength(1000).WithMessage("Maksimum 1000 Karakter");

			RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Boş Geçilemez");

			RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Boş Geçilemez");
		}
	}
}
