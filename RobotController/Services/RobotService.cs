using RobotController.Models;
using RobotController.Services.Interfaces;
using RobotController.Utilities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Services
{
    public class RobotService : IRobotService
    {
        #region [ Public Method(s) ]

        public PositionModel MoveRobot(RoomSizeModel roomsize, RobotModel robot, List<char> MovementCommandList)
        {
            PositionModel result = new PositionModel();

            if (robot is null || MovementCommandList is null)
            {
                throw new ArgumentNullException();
            }

            foreach (char movementCommand in MovementCommandList)
            {
                var tempMovement = (MovementType)Enum.Parse(typeof(MovementType), movementCommand.ToString());

                switch (tempMovement)
                {
                    case MovementType.L:
                        {
                            ManageTurnLeftCommand(robot);
                        }
                        break;
                    case MovementType.R:
                        {
                            ManageTurnRighttCommand(robot);
                        }
                        break;
                    case MovementType.F:
                        {
                            ManageMoveForwardCommand(robot);
                        }
                        break;
                }

                CheckRobotIsInRoom(roomsize, robot.CurrentPosition);
            }

            result = robot.CurrentPosition;

            return result;
        }

        private void CheckRobotIsInRoom(RoomSizeModel roomsize, PositionModel robotPisition)
        {
            if (robotPisition.WField > roomsize.WideSize || robotPisition.WField <= 0)
            {
                throw new Exception("Robot is in Never-Never Land");
            }

            if (robotPisition.DField > roomsize.DeepSize || robotPisition.DField <= 0)
            {
                throw new Exception("Robot is in Never-Never Land");
            }
        }

        #endregion

        #region [ Private Method(s) ]

        private void ManageTurnLeftCommand(RobotModel robot)
        {
            GeoDirection tempDirection = robot.CurrentPosition.GeoDirection;

            switch (robot.CurrentPosition.GeoDirection)
            {
                case GeoDirection.N:
                    tempDirection = GeoDirection.W;
                    break;
                case GeoDirection.S:
                    tempDirection = GeoDirection.E;
                    break;
                case GeoDirection.W:
                    tempDirection = GeoDirection.S;
                    break;
                case GeoDirection.E:
                    tempDirection = GeoDirection.N;
                    break;
            }

            robot.CurrentPosition.GeoDirection = tempDirection;
        }

        private void ManageTurnRighttCommand(RobotModel robot)
        {
            GeoDirection tempDirection = robot.CurrentPosition.GeoDirection;

            switch (robot.CurrentPosition.GeoDirection)
            {
                case GeoDirection.N:
                    tempDirection = GeoDirection.E;
                    break;
                case GeoDirection.S:
                    tempDirection = GeoDirection.W;
                    break;
                case GeoDirection.W:
                    tempDirection = GeoDirection.N;
                    break;
                case GeoDirection.E:
                    tempDirection = GeoDirection.S;
                    break;
            }

            robot.CurrentPosition.GeoDirection = tempDirection;
        }

        private void ManageMoveForwardCommand(RobotModel robot)
        {
            switch (robot.CurrentPosition.GeoDirection)
            {
                case GeoDirection.N:
                    robot.CurrentPosition.DField++;
                    break;
                case GeoDirection.S:
                    robot.CurrentPosition.DField--;
                    break;
                case GeoDirection.W:
                    robot.CurrentPosition.WField--;
                    break;
                case GeoDirection.E:
                    robot.CurrentPosition.WField++;
                    break;
            }
        }

        #endregion
    }
}
