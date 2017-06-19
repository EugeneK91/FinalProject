using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Entity;

namespace DAL.DTO
{
    public class DalAudioFile:IEntity
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public string Artist { get; set; }
        public byte[] Body { get; set; }
    }
}
