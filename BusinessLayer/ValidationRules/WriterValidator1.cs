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
   public class WriterValidator1 : AbstractValidator<AppUser>
    {
        public WriterValidator1()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Yazar Adı Soyadı kısmı boş geçilemez..");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez..");
            RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Şifre Boş Geçilemez...");
            RuleFor(x => x.PasswordHash).MinimumLength(1).WithMessage("Şifre en az 1 karakter olmalıdır");
            RuleFor(x => x.PasswordHash).Must(IsPasswordValid).WithMessage("Parola en az 1 karakter olmalıdır.En az bir harf ve bir sayı içermelidir");
            RuleFor(x => x.NameSurname).MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır..");
            RuleFor(x => x.NameSurname).MaximumLength(100).WithMessage("Ad en fazla 100 karakter olmalıdır..");
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
