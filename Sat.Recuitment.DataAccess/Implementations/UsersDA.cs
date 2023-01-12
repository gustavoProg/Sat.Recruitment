using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace Sat.Recruitment.DataAccess.Implementations
{
    public class UsersDA : BaseDA, IUsersDA
    {
        private List<User> _users { get; } = new List<User>();

        public UsersDA()
        {
            Load();
        }

        public IList<User> GetAll()
        {
            return _users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }



        private void Load()
        {
            var reader = ReadUsersFromFile(@"\Files\Users.txt");

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;

                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = Enum.Parse<UserType>(line.Split(',')[4].ToString()),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();
        }
    }
}
