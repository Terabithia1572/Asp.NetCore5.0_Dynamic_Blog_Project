using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı kısmı boş geçilemez..");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez..");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez...");
            RuleFor(x => x.WriterPassword).MinimumLength(1).WithMessage("Şifre en az 1 karakter olmalıdır");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Parola en az 1 karakter olmalıdır.En az bir harf ve bir sayı içermelidir");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır..");
            RuleFor(x => x.WriterName).MaximumLength(100).WithMessage("Ad en fazla 100 karakter olmalıdır..");
        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
