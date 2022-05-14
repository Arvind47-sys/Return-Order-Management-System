using Api.Data;
using Api.DTOs;
using API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UsersController(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _context = dataContext;
        }

        [HttpGet("getAllUserReturnRequests")]
        public ActionResult<UserRequestDetailsDto> GetAllUserReturnRequests()
        {
            var userRequestDetails = new UserRequestDetailsDto();

            // Getting the logged in Username from the claim in JWT
            var username = User.GetUserName();

            var userId =
             _context.Users.Where(u => u.UserName == username).Select(u => u.Id).FirstOrDefault();


            var processRequestsFromDb =
           _context.ProcessRequest.Where(req => req.AppUserId == userId).ToList();
            userRequestDetails.ProcessRequests = _mapper.Map<IEnumerable<ProcessRequestDto>>(processRequestsFromDb);

            var processResponsesFromDb =
            _context.ProcessResponses.Where(resp => resp.AppUserId == userId).ToList();
            userRequestDetails.ProcessResponses = _mapper.Map<IEnumerable<ProcessResponseDto>>(processResponsesFromDb);


            return userRequestDetails;
        }
    }
}