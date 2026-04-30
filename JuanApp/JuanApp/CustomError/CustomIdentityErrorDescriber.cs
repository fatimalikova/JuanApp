using Microsoft.AspNetCore.Identity;

namespace JuanApp.CustomError
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        //public override IdentityError PasswordTooShort(int length)
        //{
        //    return new IdentityError
        //    {
        //        Code = nameof(PasswordTooShort),
        //        Description = $"Parolanız en az {length} karakter olmalıdır."
        //    };
        //}

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "Loremm Your password must contain at least one non-alphanumeric character."
            };
        }
    }
}
