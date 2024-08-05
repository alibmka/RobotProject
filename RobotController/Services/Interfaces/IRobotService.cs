using RobotController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Services.Interfaces
{
    public interface IRobotService
    {
        PositionModel MoveRobot(RoomSizeModel roomsize, RobotModel robot, List<char> MoveCommandList);
    }
}
