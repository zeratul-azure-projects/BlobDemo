using BlobDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobDemo.Services
{
    public interface IFileManager
    {
        Task<byte[]> Get(string imageName);
        Task Upload(FileModel model);
        Task Delete(string imageName);
    }
}
