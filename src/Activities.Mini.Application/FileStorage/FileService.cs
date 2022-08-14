using Activities.Mini.FileStorage;
using Activities.Mini.Core.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Activities.Mini.Common;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Activities.Mini.FileStorage
{
    public class FileService : MiniAppService, IFileService
    {
        private readonly IBlobContainer<ProfilePictureContainer> _blobContainer;
        private readonly IConfiguration _configuration;

        public FileService(IBlobContainer<ProfilePictureContainer> blobContainer,
            IConfiguration configuration)
        {
            _blobContainer = blobContainer;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IApiResult> UploadAsync(IFormFile file)
        {
            try
            {
                string extention = Path.GetExtension(file.FileName);
                var bytes = await file.GetBytesAsync();
                var fileName = Guid.NewGuid().ToString() + extention;
                await _blobContainer.SaveAsync(fileName, bytes);
                var downloadBasUri = _configuration["App:DownloadBaseUri"];
                var result = new UploadFileResultDto(fileName, downloadBasUri + fileName);
                return ApiResult.Succeed(result);
            }
            catch (Exception ex)
            {
                return ApiResult.Failed("请求失败：" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<FileContentResult> DownloadAsync(string fileName)
        {
            var bytes = await _blobContainer.GetAllBytesOrNullAsync(fileName);
            var result = new FileContentResult(bytes, "application/octet-stream")
            {
                FileDownloadName = fileName
            };
            return result;
        }
    }
}
