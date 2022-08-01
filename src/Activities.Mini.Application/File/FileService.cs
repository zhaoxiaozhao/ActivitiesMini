using Activities.Mini.File;
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

namespace Activities.Mini.File
{
    public class FileService : MiniAppService, IFileService
    {
        private readonly IBlobContainer _blobContainer;
        private readonly IConfiguration _configuration;

        public FileService(IBlobContainer blobContainer,
            IConfiguration configuration)
        {
            _blobContainer = blobContainer;
            _configuration = configuration;
        }

        public async Task<IApiResult> UploadAsync(IFormFile file)
        {
            try
            {
                string extention = Path.GetExtension(file.FileName);
                var bytes = await file.GetBytesAsync();
                var fileName = Guid.NewGuid().ToString() + extention;
                await _blobContainer.SaveAsync(fileName, bytes);
                return new ApiResult<UploadFileResultDto>
                {
                    StatusCode = 200,
                    Message = "上传成功",
                    Result = new UploadFileResultDto(fileName, "")
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IApiResult> DownloadAsync(string fileName)
        {
            var bytes = await _blobContainer.GetAllBytesOrNullAsync(fileName);
            //return PhysicalFile(bytes, "image/jpeg");
            return ApiResult.Succeed(bytes);
        }
    }
}
