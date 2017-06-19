using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Entity;

namespace DAL.DTO
{
    public class DalAudioRating : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AudioFileId { get; set; }
        public decimal Rating { get; set; }
    }
}
