using RobotController.Models;
using RobotController.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Services
{
    public class RoomService : IRoomService
    {
        #region [ Constructor(s) ]

        public RoomService()
        {
        }

        #endregion

        #region [ Public Method(s) ]

        public RoomModel SetupRoom(uint wideSize, uint deepSize)
        {
            RoomModel result = null;

            result = new RoomModel();

            result.RoomSize.DeepSize = deepSize;
            result.RoomSize.WideSize = wideSize;

            return result;
        }

        public void AddRobotInRoom(RoomModel room, RobotModel robot)
        {
            if (robot is null)
            {
                throw new ArgumentNullException();
            }

            ValidateInitRobotData(room, robot);

            room.Robots.Add(robot);
        }

        #endregion

        #region [ Private Method(s) ]

        private void ValidateInitRobotData(RoomModel room, RobotModel robot)
        {
            if (room is null)
            {
                throw new Exception("First, the room should be initiated");
            }

            if (robot.CurrentPosition.WField == 0 || robot.CurrentPosition.DField == 0)
            {
                throw new Exception("Robot init wide|deep fields could not be zero");
            }

            if (room.RoomSize.WideSize < robot.CurrentPosition.WField || room.RoomSize.DeepSize < robot.CurrentPosition.DField)
            {
                throw new Exception($"Robot init in out of room size({room.RoomSize.WideSize} {room.RoomSize.DeepSize})");
            }
        }

        private void ValidateInitRoomCommandData(uint wide, uint deep)
        {
            if (wide == 0 || deep == 0)
            {
                throw new Exception("Room init wide|deep fields could not be zero");
            }
        }

        #endregion 
    }
}
