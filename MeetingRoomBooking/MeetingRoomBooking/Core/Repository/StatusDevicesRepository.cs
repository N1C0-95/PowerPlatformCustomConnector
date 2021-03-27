using MeetingRoomBooking.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomBooking.Core.Repository
{


    public class MeetingRoomBookingRepository : IMeetingRoomBookingRepository
    {
        //List<DeviceStatus> _roomStatuses = new List<DeviceStatus>();
        List<RoomStatus> _roomStatuses = new List<RoomStatus>();

        public MeetingRoomBookingRepository()
        {
            this._roomStatuses.Add(Data.Sala1);
            this._roomStatuses.Add(Data.Sala2);
            this._roomStatuses.Add(Data.Sala3);
            this._roomStatuses.Add(Data.Sala4);
        }
        public List<RoomStatus> Get()
        {
            return _roomStatuses;
        }

        public RoomStatus FindRoom(string name)
        {
            try
            {
                RoomStatus room = _roomStatuses.Where(w => w.Name == name).FirstOrDefault();
                if(room is not null)
                {
                    return room;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }

        }

        public Task<bool> UpdateRoomStatus(Guid guid, int value)
        {
            var update = _roomStatuses.FirstOrDefault(w => w.Guid == guid);
            if (update is not null)
            {
                try
                {
                    update.StatusLocation = value;
                    return Task.FromResult(true);
                }
                catch (Exception ex)
                {
                    throw new ArgumentNullException(ex.ToString());
                }
            }
            else
            {
                return Task.FromResult(false);
            }

        }
    }
    public static class Data
    {

        public static DeviceStatus Device1 = new DeviceStatus() { Guid = Guid.NewGuid(), Name = "Sala1_SS", PercentualStatus = 100, Timestamp = DateTime.Now, ErrorInfo = "" };
        public static DeviceStatus Device2 = new DeviceStatus() { Guid = Guid.NewGuid(), Name = "Sala2_SS", PercentualStatus = 0, Timestamp = DateTime.Now, ErrorInfo = "Bad Request" };
        public static DeviceStatus Device3 = new DeviceStatus() { Guid = Guid.NewGuid(), Name = "Sala3_SS", PercentualStatus = 100, Timestamp = DateTime.Now, ErrorInfo = "" };
        public static DeviceStatus Device4 = new DeviceStatus() { Guid = Guid.NewGuid(), Name = "Sala4_SS", PercentualStatus = 0, Timestamp = DateTime.Now, ErrorInfo = "Connection Low" };

        public static RoomStatus Sala1 = new RoomStatus() { Guid = Guid.NewGuid(), Name = "Sala 1", StatusLocation = 1, Device = Device1 };
        public static RoomStatus Sala2 = new RoomStatus() { Guid = Guid.NewGuid(), Name = "Sala 2", StatusLocation = 1, Device = Device2 };
        public static RoomStatus Sala3 = new RoomStatus() { Guid = Guid.NewGuid(), Name = "Sala 3", StatusLocation = 0, Device = Device3 };
        public static RoomStatus Sala4 = new RoomStatus() { Guid = Guid.NewGuid(), Name = "Sala 4", StatusLocation = 1, Device = Device4 };


    }

}
