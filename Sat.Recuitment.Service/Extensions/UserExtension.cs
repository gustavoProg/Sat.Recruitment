using Sat.Recruitment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Service.Extensions
{
    public static class UserExtension
    {
        public static void NormalizeEmail(this User user)
        {
            var aux = user.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            user.Email = string.Join("@", new string[] { aux[0], aux[1] });

        }

        public static void CalculateGif(this User user, IList<GifRange> gifRanges)
        {
            var rangesFilter = gifRanges.Where(x => x.UserType == user.UserType);

            decimal gif = 0;

            foreach (var item in rangesFilter)
            {
                if (user.Money > item.Min && user.Money < item.Max)
                {
                    gif = user.Money * item.Percentage;
                }
            }
            user.Money += gif;
        }

        public static bool IsDuplicated(this User user, IList<User> users)
        {
            if (users.Any(x => x.Email == user.Email
                            || x.Phone == user.Phone
                            || x.Name == user.Name))
            {
                return true;
            }
            return false;
        }
    }
}
