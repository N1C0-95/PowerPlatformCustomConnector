using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Controllers.Response
{
    public class RoomResponse
    {
        public RoomResponse()
        {
               
        }
        public RoomResponse(string guid, string description)
        {
            this.Guid = guid;
            this.Description = description;
        }
        public string Guid { get; set; }
        public string Description { get; set; }
    }
}
