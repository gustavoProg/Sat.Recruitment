using Sat.Recruitment.Core.Entities;
using System.Collections.Generic;

namespace Sat.Recruitment.DataAccess.Interfaces
{
    public interface IUsersDA
    {
        IList<User> GetAll();

        public void Add(User user);

    }
}