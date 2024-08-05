using RobotController.Interfaces;
using RobotController.Models;
using RobotController.Services.Interfaces;
using RobotController.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotController
{
    public class Controller : IController
    {
        #region [ Constructor(s) ]

        public Controller(IRoomService roomService, IRobotService robotService)
        {
            _roomService = roomService;
            _robotService = robotService;
        }

        #endregion

        #region [ Public Method(s) ]

        public void InitRoom(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException();
            }
            if (room is not null)
            {
                throw new Exception("The room has been initiated");
            }

            (var wide, var deep) = CommandHelper.ParsRoomInitCommand(command);

            room = _roomService.SetupRoom(wide, deep);
        }

        public void InitRobot(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException();
            }

            (var wide, var deep, var direction) = CommandHelper.ParsRobotInitCommand(command);

            RobotModel tempRobotModel = new RobotModel()
            {
                CurrentPosition = new PositionModel() { DField = deep, WField = wide, GeoDirection = direction },
                Name = Guid.NewGuid().ToString(),
            };

            _roomService.AddRobotInRoom(room, tempRobotModel);
        }

        public PositionModel MoveRobot(string command)
        {
            PositionModel result = null;

            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException();
            }
            if (room is null || room.Robots.Count() == 0)
            {
                throw new Exception("First, room and robot needs to be initiated");
            }

            var tempMovementList = CommandHelper.ParsMoveRobotCommand(command);
            var selectedRobot = room.Robots.First();

            result = _robotService.MoveRobot(room.RoomSize, selectedRobot, tempMovementList);

            return result;
        }

        #endregion

        #region [ Private Field(s) ]

        private readonly IRoomService _roomService = null;
        private readonly IRobotService _robotService = null;
        private RoomModel room = null;

        #endregion

    }
}

