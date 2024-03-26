using FileMngt.Consts;
using FileMngt.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileMngt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly ILogger<FileUploadController> _logger;
        readonly IFileUploadService _fileUploadService;
        readonly IReadFileItems _readfileItems;
        public FileUploadController(ILogger<FileUploadController> logger, IFileUploadService fileUploadService, IReadFileItems readfileItems)
        {
            _logger = logger;
            _fileUploadService = fileUploadService;
            _readfileItems = readfileItems;
        }
        [HttpPost]
        public async Task<ActionResult> SaveFileUsingBuffered(IFormFile file)
        {
            try
            {
                _logger.LogInformation(CommonConsts.FILEUPLOAD_SUCCESS_MSG);
                return Ok(await _fileUploadService.UploadFile(file));
            }
            catch (Exception ex)
            {   
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation(CommonConsts.GET_ALL_FILEITEM_MSG);
            return Ok( await _readfileItems.GetFiles());
        }
        [HttpGet]
        public async Task<IActionResult> Get(Guid fileitemid)
        {
            _logger.LogInformation(CommonConsts.GET_FILEITEM_BY_ID_MSG);
            return Ok(await _readfileItems.GetFileById(fileitemid));
        }
    }
}
