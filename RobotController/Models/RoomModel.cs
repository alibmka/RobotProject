using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Models
{
    public class RoomModel
    {
        #region [ Constructor(s) ]

        public RoomModel()
        {
            RoomSize = new RoomSizeModel();
            Robots = new List<RobotModel>();
        }

        #endregion

        #region [ Public Property(s) ]

        public RoomSizeModel RoomSize { get; set; }

        public List<RobotModel> Robots { get; set; }

        #endregion    
    }
}
