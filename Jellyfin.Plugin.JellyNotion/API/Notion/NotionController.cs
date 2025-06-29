using Jellyfin.Plugin.JellyNotion.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jellyfin.Plugin.JellyNotion.API.Notion
{
    [ApiController]
    [Authorize]
    [Route("JellyNotion")]
    public class NotionController : ControllerBase
    {
        private readonly NotionAPI _notionAPI;
        public NotionController(NotionAPI notionAPI)
        {
            _notionAPI = notionAPI;
        }
        [HttpPost("GetDatabases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<Result>>> GetDatabases([FromBody] GetDatabasesRequest body)
        {
            //var userConfiguration = Plugin.Instance?.Configuration.GetConfigbyGuid(userGuid);
            //if (userConfiguration == null || userConfiguration.DatabaseInfo == null) return NotFound();
            return Ok(await _notionAPI.GetDatabases(body.Token).ConfigureAwait(false));
        }
    }
}
