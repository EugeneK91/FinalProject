using BLL.Entities;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcSearchModelMappers
    {
        public static BllSearchModel ToBllSearchModel(this SearchModel model)
        {
            return new BllSearchModel
            {
                Artist = model.Artist,
                Genre = model.Genre,
                SongName = model.SongName
            };
        }
    }
}