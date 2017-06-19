using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public partial class AudioRating : IEntity
    {
        public int  Id { get; set; }
        public int  UserId { get; set; }
        public int  AudioFileId { get; set; } 
        public decimal Rating { get; set; }
    }
}
