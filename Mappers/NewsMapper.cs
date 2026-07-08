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

        public static NewsDetailDto ToNewsDetailDto(this GetNewsByIdResult model)
        {
            return new NewsDetailDto
            {
                NewsId = model.NewsId,
                NewsGuid = model.NewsGuid,
                Title = model.Title,
                Body = model.Body,
                NewsDate = model.NewsDate,
                FileName = model.FileName,
                File = model.File,
                FileTypeId = model.FileTypeId,
                IsMainPic = model.IsMainPic,
                Extension = model.Extension
            };
        }
    }
}