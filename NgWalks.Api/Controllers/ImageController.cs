using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgWalks.Api.Migrations;
using NgWalks.Api.Models.Domain;
using NgWalks.Api.Models.DTO;
using NgWalks.Api.Repositories;

namespace NgWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ILocalImageRepository localImageRepository;

        public ImageController(ILocalImageRepository localImageRepository)
        {
            this.localImageRepository = localImageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] UploadFileDto uploadFileDto)
        {
            ValidateFileUpload(uploadFileDto);

            if(ModelState.IsValid)
            {
                //Convert Dto to Model

                var imageDomainModel = new Image
                {
                    File = uploadFileDto.File,
                    FileName = uploadFileDto.FileName,
                    FileExtension = Path.GetExtension(uploadFileDto.File.FileName),
                    FileDiscription = uploadFileDto.FileDiscription,
                    FileSizeInByte = uploadFileDto.File.Length,

                };

                await localImageRepository.UploadImageAsync(imageDomainModel);
                return Ok(imageDomainModel);

            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload (UploadFileDto uploadFile)
        {
            var allowFileExtension = new string[] { ".pdf", ".png",".jpg", ".jpeg" };
             
            if(!allowFileExtension.Contains(Path.GetExtension(uploadFile.File.FileName)))
            {
                ModelState.AddModelError("File", "Unsupported file extension.");
            }

            if(uploadFile.File.Length > 10485760)
            {
                ModelState.AddModelError("File", "File too large");
            }
        }
    }
}
