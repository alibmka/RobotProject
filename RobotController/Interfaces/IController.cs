using RobotController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Interfaces
{
    public interface IController
    {
        void InitRoom(string command);

        void InitRobot(string command);

        PositionModel MoveRobot(string command);
    }
}
