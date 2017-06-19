using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IAudioRatingService
    {
        void SetRating(int songId, decimal rating, int userId);
        decimal GetRating(int songId, int userId);
    }
}
