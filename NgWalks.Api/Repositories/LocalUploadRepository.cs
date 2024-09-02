using NgWalks.Api.Data;
using NgWalks.Api.Models.Domain;

namespace NgWalks.Api.Repositories
{
    public class LocalUploadRepository : ILocalImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NgWalksDbContext dbContext;

        public LocalUploadRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NgWalksDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<Image> UploadImageAsync(Image image)
        {
            var localPathFile = Path.Combine(webHostEnvironment.ContentRootPath, "Images",$"{image.FileName}{image.FileExtension}");

            //Upload Image to local Path
            using var stream = new FileStream(localPathFile, FileMode.Create);
            await image.File.CopyToAsync(stream);

            //https://localhost:2028/image/image.jpg

            var filePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}" +
                $"{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = filePath;

            //save to database

            await dbContext.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;


        }
    }
}
