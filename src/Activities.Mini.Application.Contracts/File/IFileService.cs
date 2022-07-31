using Activities.Mini.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Activities.Mini.File
{
    public interface IFileService
    {
        public Task<IApiResult> UploadAsync(IFormFile file);

        public Task<IApiResult> DownloadAsync(string fileName);
    }
}
