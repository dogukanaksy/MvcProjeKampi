using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Açıklamasını Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Yazar Adı En Az 2 Karakter Olmalıdır");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Yazar Adı En Fazla 50 Karakter Olmalıdır");
            RuleFor(x => x.WriterAbout).Cascade(CascadeMode.Stop).Must(x => x.Contains("a")).WithMessage("Hakkında kısmında 'a' harfi geçmelidir");


        }
    }
}
