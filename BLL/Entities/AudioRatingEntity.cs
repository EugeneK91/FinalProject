using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class AudioRatingEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AudioFileId { get; set; }
        public decimal Rating { get; set; }
    }
}
