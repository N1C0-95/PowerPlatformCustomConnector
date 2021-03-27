using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Controllers
{
    public class ErrorInfo
    {
        public ErrorInfo()
        {

        }
        public ErrorInfo(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
