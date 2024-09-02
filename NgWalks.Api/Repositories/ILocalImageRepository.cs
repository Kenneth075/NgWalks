using NgWalks.Api.Models.Domain;

namespace NgWalks.Api.Repositories
{
    public interface ILocalImageRepository
    {
        Task<Image> UploadImageAsync(Image image);
    }
}
