using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator:AbstractValidator<Comment>
    {
		public CommentValidator()
		{
			RuleFor(x => x.CommentTitle)
				.NotEmpty().WithMessage("Yorum Başlığı Boş Geçilemez")
				.MaximumLength(40).WithMessage("Maksimum 40 Karakter")
				.MinimumLength(2).WithMessage("Minumum 2 Karakter");

			RuleFor(x => x.CommentContent)
				.NotEmpty().WithMessage("Yorum Başlığı Boş Geçilemez")
				.MaximumLength(400).WithMessage("Maksimum 400 Karakter")
				.MinimumLength(2).WithMessage("Minumum 5 Karakter");

			RuleFor(x => x.CommentUserName)
				.NotEmpty().WithMessage("Yorum Başlığı Boş Geçilemez")
				.MaximumLength(40).WithMessage("Maksimum 40 Karakter")
				.MinimumLength(2).WithMessage("Minumum 2 Karakter");

		}
	}
}
