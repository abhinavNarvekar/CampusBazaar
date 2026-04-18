using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

public class CloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService()
    {
        var account = new Account(
            Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME"),
            Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY"),
            Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET")
        );

        _cloudinary = new Cloudinary(account);
    }

    public string UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return null;

        using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, stream),
            Folder = "CampusBazaar/listings",
            PublicId = Guid.NewGuid().ToString()
        };

        var result = _cloudinary.Upload(uploadParams);

        return result.SecureUrl.ToString();
    }
}