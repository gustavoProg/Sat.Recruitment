using System;
using System.IO;

namespace Sat.Recruitment.DataAccess.Implementations
{
    public class BaseDA
    {

        internal StreamReader ReadUsersFromFile(string filePathName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + filePathName;

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);

            return reader;
        }
    }
}
