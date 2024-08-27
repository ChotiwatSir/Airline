using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.NoFlyList;
using ToToAirline.IService;
using ToToAirline.Models.NoFlyList;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class NoFlyListController:ControllerBase
    {
        private readonly INoFlyListService _noFlyListService;

        public NoFlyListController(INoFlyListService noFlyListService)
        {
            _noFlyListService = noFlyListService;
        }
        [HttpGet("{PassengerId}")]
        public IActionResult GetNoFlyList(Guid PassengerId)
        {
            var noflylist = _noFlyListService.GetNoFlyList(PassengerId);
            var dto = new GetNoFlyListResponse(noflylist.Id, noflylist.ActiveFrom, noflylist.ActiveTo);
            var response = new BaseResponse<GetNoFlyListResponse>(status: true, "200", msg: "Succesed", dto);

            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateNoFlyList([FromBody] CreateNoFlyListRequest create)
        {
            _noFlyListService.CreateNoFlyList(new CreateNoFlyListDto(create.ActiveFrom,create.ActiveTo,create.PassengerId));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
    }
}