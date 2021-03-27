using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Controllers.Request
{
    public class RoomRequest
    {

        [FromBody]
        [Required]
        public string Name { get; set; }
        [FromBody]
        public int Value { get; set; }

    }
}
