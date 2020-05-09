using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.Primitives;

public static void Run(Stream inputBlob, Stream outputBlob, string name, ILogger log)
{
    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");
    using (Image<Rgba32> image = Image.Load(inputBlob))
    {
        image.Mutate(i => i.Resize(new ResizeOptions { Size = new Size(250, 250), Mode = ResizeMode.Max }).Grayscale());
        image.Save(outputBlob, new JpegEncoder());
    }
}