using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Unik.Application.Commands.Item;
using Unik.Application.Commands.Item.DTO;
using Unik.Application.Queries.Item;
using Unik.Application.Queries.Item.QueryResultDto;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IGetAllItemQuery _getAllItemQuery;
        private readonly IGetItemQuery _getItemQuery;
        private readonly ICreateItemCommand _createItemCommand;
        private readonly IEditItemCommand _editItemCommand;
        private readonly IDeleteItemCommand _deleteItemCommand;

        public ItemController(IGetAllItemQuery getAllItemQuery, IGetItemQuery getItemQuery, ICreateItemCommand createItemCommand, IEditItemCommand editItemCommand, IDeleteItemCommand deleteItemCommand)
        {
            _getAllItemQuery = getAllItemQuery;
            _getItemQuery = getItemQuery;
            _createItemCommand = createItemCommand;
            _editItemCommand = editItemCommand;
            _deleteItemCommand = deleteItemCommand;
        }
        [HttpPost("create")] //api/Item/create
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(ItemCreateRequestDto dto)
        {
            try
            {
                _createItemCommand.CreateItem(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}/")] //api/Item/delete/{id}
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ItemDeleteRequestDto> Delete(int id)
        {
            try
            {
                _deleteItemCommand.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("edit")] //api/Item/edit
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult Put([FromBody] ItemEditRequestDto dto)
        {
            try
            {
                _editItemCommand.Edit(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getall")] //api/Item/getall
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemQueryResultDto>> Get()
        {
            try
            {
                var items = _getAllItemQuery.GetAllItem();
                return items.ToList();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] //api/Item/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ItemQueryResultDto> Get(int id)
        {
            try
            {
                return Ok(_getItemQuery.GetItem(id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
