using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interface
{
    public interface IAudioFileService
    {
        IEnumerable<AudioFileEntity> GetAllFiles();
        void SaveFile(AudioFileEntity audioFile);
        AudioFileEntity GetById(int id);
        void DeleteFile(int id);
        IEnumerable<AudioFileEntity> SerchAudioFiles(BllSearchModel model);
    }
}
