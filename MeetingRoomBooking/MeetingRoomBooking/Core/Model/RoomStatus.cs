using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Core.Model
{
    public class RoomStatus
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int StatusLocation { get; set; }
        public DeviceStatus Device { get; set; }
    }
}
