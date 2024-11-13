using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StreamController: ControllerBase {

    private readonly BlobServiceClient _blobSvcClient;

    public StreamController(BlobServiceClient blobSvcClient) 
    { 
        _blobSvcClient = blobSvcClient;
    }

    [HttpGet()]
    public async Task<IActionResult> Stream(CancellationToken ct)
    {
        // BlobContainerClient cc = _blobSvcClient.GetBlobContainerClient("videos");
        // var blobClient = cc.GetBlobClient("radix.mp4");
        // var ranges = Request.GetTypedHeaders().Range?.Ranges;
        
        // if (ranges == null || ranges.Count != 1 || !ranges.First().From.HasValue) {
        //     return BadRequest("missing range headers");
        // }

        // var props = await blobClient.GetPropertiesAsync(cancellationToken: ct);
        // var blobStream = await blobClient.OpenReadAsync(position: ranges.First().From!.Value, bufferSize: null, cancellationToken: ct);
    
        // return File(blobStream, props.Value.ContentType, enableRangeProcessing: true);

        throw new NotImplementedException();
    }
}