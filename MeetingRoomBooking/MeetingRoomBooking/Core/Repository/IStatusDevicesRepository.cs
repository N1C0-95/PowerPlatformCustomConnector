using MeetingRoomBooking.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Core.Repository
{
    public interface IMeetingRoomBookingRepository
    {
        List<RoomStatus> Get();
        Task<bool> UpdateRoomStatus(Guid guid, int value);
        RoomStatus FindRoom(string name);
    }
}
