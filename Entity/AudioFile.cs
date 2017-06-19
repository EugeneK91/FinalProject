using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Entity
{
    public partial class AudioFile : IEntity
    {
        public int  Id { get; set; }
        public string SongName { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public string Artist { get; set; }
        public byte[] Body { get; set; }
    }
}
