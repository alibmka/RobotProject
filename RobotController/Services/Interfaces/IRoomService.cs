using RobotController.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Services.Interfaces
{
    public interface IRoomService
    {
        RoomModel SetupRoom(uint wideSize, uint deepSize);

        void AddRobotInRoom(RoomModel room, RobotModel robot);
    }
}
