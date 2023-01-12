using Sat.Recruitment.Core.Entities;
using System.Collections.Generic;

namespace Sat.Recruitment.DataAccess.Interfaces
{
    public interface IGifsDA
    {
        IList<GifRange> GetAll();
    }
}