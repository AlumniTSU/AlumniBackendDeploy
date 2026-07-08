using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.News;
using backend.Results.News;

namespace backend.Mappers
{
    public static class NewsMapper
    {
        public static NewsDto ToNewsDto(this GetNewsByLanguageIdResult model)
        {
            return new NewsDto
            {
                NewsId = model.NewsId,
                NewsGuid = model.NewsGuid,
                Title = model.Title,
                Body = model.Body,
                NewsDate = model.NewsDate
            };
        }
    }
}