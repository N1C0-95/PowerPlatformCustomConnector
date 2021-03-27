using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Core.Model
{
    public class DeviceStatus
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal PercentualStatus { get; set; }
        public string ErrorInfo { get; set; }
        
    }
}
