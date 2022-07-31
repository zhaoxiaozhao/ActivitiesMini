using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activities.Mini.Common;

namespace Activities.Mini.File
{
    public class UploadFileResultDto
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public UploadFileResultDto() { }
        public UploadFileResultDto(string fileName, string url) 
        {
            Url = url;
            FileName = fileName;
        }
    }
}
