using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlobDemo.Models;
using BlobDemo.Services;

namespace BlobDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IFileManager _fileManager;

        public ImageController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] FileModel model)
        {
            if(model.ImageFile != null)
            {
                await _fileManager.Upload(model);
            }
            return Ok();
        }

        [Route("get")]
        [HttpPost]
        public async Task<IActionResult> Get(string fileName)
        {
            var imgBytes = await _fileManager.Get(fileName);
            return File(imgBytes, "image/jpg");
        }

        [Route("download")]
        [HttpPost]
        public async Task<IActionResult> Download(string fileName)
        {
            var imgBytes = await _fileManager.Get(fileName);
            return new FileContentResult(imgBytes, "applicaion/octet-stream")
            {
                FileDownloadName = Guid.NewGuid().ToString() + ".jpg"
            };
        }

        [Route("delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(string fileName)
        {
            await _fileManager.Delete(fileName);
            return Ok();
        }
    }
}
