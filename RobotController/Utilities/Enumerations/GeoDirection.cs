using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Utilities.Enumerations
{
    public enum GeoDirection
    {
        [Display(Name = "North")]
        N,
        [Display(Name = "South")]
        S,
        [Display(Name = "West")]
        W,
        [Display(Name = "East")]
        E
    }
}
