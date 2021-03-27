using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeetingRoomBooking.Controllers.Request;
using MeetingRoomBooking.Controllers.Response;
using MeetingRoomBooking.Core.Model;
using MeetingRoomBooking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MeetingRoomBookingController : ControllerBase
    {
        private readonly IMeetingRoomBookingRepository _statusRoom;
        
        public MeetingRoomBookingController(IMeetingRoomBookingRepository meetingRoomBookingRepository)
        {
            this._statusRoom = meetingRoomBookingRepository;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_statusRoom.Get());
        }
                
        [HttpPut]
        [Route("/api/[controller]/update")]        
        public async Task<IActionResult> UpdateStatusRoom(RoomRequest roomRequest, [FromHeader(Name ="API-KEY")] string apiKey = "")
        {
            if(apiKey == null)
            {
                return StatusCode(401);
            }
            else
            {
                if( apiKey == "DumboVola")
                {
                    try
                    {
                        
                        RoomStatus room = _statusRoom.FindRoom(roomRequest.Name);
                        if(room is not null)
                        {
                            Guid guid = room.Guid;
                            var response = await _statusRoom.UpdateRoomStatus(guid, roomRequest.Value);
                            return Ok(new RoomResponse()
                            {
                                Guid = room.Guid.ToString(),
                                Description = "Record Aggiornato"
                            }) ;                            
                        }
                        else
                        {
                            return NotFound(new ErrorInfo("Not Found", "Nome della Sala non trovato"));
                        }
                    }
                        
                    catch (Exception ex)
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError);
                    }
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ErrorInfo("auth-error", "Chiave API non valida"));
                }
            }
           
            
        }
                   

    }
}
