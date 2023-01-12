using Sat.Recruitment.DataAccess.Interfaces;
using Sat.Recruitment.Core.Entities;
using System;
using System.Collections.Generic;

namespace Sat.Recruitment.DataAccess.Implementations
{
    public class GifsDA : BaseDA, IGifsDA
    {
        private IList<GifRange> _gifRanges { get; } = new List<GifRange>();

        public GifsDA()
        {
            Load();
        }

        public IList<GifRange> GetAll()
        {
            return _gifRanges;
        }

        private void Load()
        {
            var reader = ReadUsersFromFile(@"\Files\Gifs.txt");

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;

                var lineFields = line.Split(';');

                var gifRange = new GifRange();

                gifRange.UserType = lineFields[0].ToString();

                gifRange.Min = string.IsNullOrEmpty(lineFields[1].ToString()) ? decimal.MinValue : Convert.ToDecimal(lineFields[1]);

                gifRange.Max = string.IsNullOrEmpty(lineFields[2].ToString()) ? decimal.MaxValue : Convert.ToDecimal(lineFields[2]);

                gifRange.Percentage = Convert.ToDecimal(lineFields[3].ToString());

                _gifRanges.Add(gifRange);
            }
            reader.Close();
        }
    }
}
