using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Models
{
    public class RoomSizeModel
    {
        #region [ Constructor(s) ]

        public RoomSizeModel()
        {
            WideSize = 0;
            DeepSize = 0;
        }

        #endregion

        #region [ Public Property(s) ]

        public uint WideSize { get; set; }

        public uint DeepSize { get; set; }

        #endregion   
    }
}
