using RobotController;
using RobotController.Interfaces;
using RobotController.Models;
using RobotController.Services;
using RobotController.Services.Interfaces;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            IRoomService roomService = new RoomService();
            IRobotService robotService = new RobotService();
            controller = new Controller(roomService, robotService);
        }

        [TestCase("5 5")]
        [TestCase("15 1235")]
        public void InputValidRoomInitCommand_ShouldNotThowException(string command)
        {
            Assert.DoesNotThrow(() => controller.InitRoom(command));
        }

        [TestCase("15 15", "5 5 N")]
        [TestCase("20 2000", "15 1235 S")]
        public void InputValidRobotInitCommand_ShouldNotThowException(string roomCommand, string RobotCommand)
        {
            controller.InitRoom(roomCommand);
            Assert.DoesNotThrow(() => controller.InitRobot(RobotCommand));
        }

        [Test]
        public void InputValidRobotMovementCommand_ShouldChangeRobotPoisiton()
        {
            controller.InitRoom("15 15");
            controller.InitRobot("5 5 N");

            var actualRobotPosition = controller.MoveRobot("LFFRFRFRFF");
            var expectedRobotPosition = new PositionModel()
            {
                DField = 4,
                WField = 4,
                GeoDirection = RobotController.Utilities.Enumerations.GeoDirection.S
            };

            Assert.AreEqual(expectedRobotPosition.WField, actualRobotPosition.WField);
            Assert.AreEqual(expectedRobotPosition.DField, actualRobotPosition.DField);
            Assert.AreEqual(expectedRobotPosition.GeoDirection, actualRobotPosition.GeoDirection);

        }

        [Test]
        public void InputValidRobotMovementCommand_ShouldThowException()
        {
            controller.InitRoom("4 4");
            controller.InitRobot("3 3 N");

            Assert.Throws<Exception>(() => controller.MoveRobot("LFFFFFFFRFRFRFF"));
        }

        private IController controller = null;
    }
}