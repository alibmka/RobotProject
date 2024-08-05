using RobotController.Utilities.Enumerations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Models
{
    public class RobotModel
    {
        #region [ Constructor(s) ]

        public RobotModel()
        {
            Name = string.Empty;
            CurrentPosition = new PositionModel();
            IsRobottInlandRange = true;
        }

        #endregion

        #region [ Public Property(s) ]

        public string Name { get; set; }

        public PositionModel CurrentPosition { get; set; }

        public bool IsRobottInlandRange { get; set; }

        #endregion    
    }
}
