using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobDemo.Models
{
    public class FileModel
    {
        public IFormFile ImageFile { get; set; }
    }
}
