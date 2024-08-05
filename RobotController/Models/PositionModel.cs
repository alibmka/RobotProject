using RobotController.Utilities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Models
{
    public class PositionModel
    {
        #region [ Constructor(s) ]

        public PositionModel()
        {
            WField = 0;
            DField = 0;
            GeoDirection = GeoDirection.N;
        }

        #endregion

        #region [ Public Property(s) ]

        public int WField { get; set; }

        public int DField { get; set; }

        public GeoDirection GeoDirection { get; set; }

        #endregion
    }
}
