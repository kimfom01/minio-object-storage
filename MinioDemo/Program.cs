using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using MinioDemo;

var credentials = CredentialsHelper.LoadCredentials("./credentials.json");

IMinioClient client = new MinioClient()
    .WithEndpoint(credentials?.Url)
    .WithCredentials(credentials?.AccessKey, credentials?.SecretKey)
    .Build();

var bucketName = "demo";
var objectName = "image-upload.jpg";
var filePath = "image-upload.jpg";
var contentType = "image/jpg";

try
{
    var beArgs = new BucketExistsArgs().WithBucket(bucketName);

    bool found = await client.BucketExistsAsync(beArgs);

    if (!found)
    {
        var mbArgs = new MakeBucketArgs().WithBucket(bucketName);
        await client.MakeBucketAsync(mbArgs);
    }

    var pgoArgs = new PresignedGetObjectArgs()
        .WithBucket(bucketName)
        .WithObject(objectName)
        .WithExpiry(60 * 60 * 2);

    var downloadUrl = await client.PresignedGetObjectAsync(pgoArgs);

    var putObjectArgs = new PutObjectArgs()
        .WithBucket(bucketName)
        .WithObject(objectName)
        .WithFileName(filePath)
        .WithContentType(contentType);

    var response = await client.PutObjectAsync(putObjectArgs);
    Console.WriteLine(downloadUrl);
    Console.WriteLine("Successfully uploaded " + objectName);
}
catch (MinioException ex)
{
    Console.WriteLine(ex.Message);
}
