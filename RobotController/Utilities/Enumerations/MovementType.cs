using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Utilities.Enumerations
{
    public enum MovementType
    {
        [Display(Name = "TurnLeft")]
        L,
        [Display(Name = "TurnRight")]
        R,
        [Display(Name = "WalkForward")]
        F
    }
}
