using RobotController.Utilities.Enumerations;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotController.Utilities.Helpers
{
    public static class CommandHelper
    {
        public static (int, int, GeoDirection) ParsRobotInitCommand(string command)
        {
            int wide = 0;
            int deep = 0;
            GeoDirection direction = GeoDirection.N;

            try
            {
                command = command.ToUpper();
                string pattern = @"^(\d+)\s(\d+)\s([NSWE])$";
                Match tempMatch = Regex.Match(command, pattern);
                if (tempMatch != null && tempMatch.Success)
                {
                    wide = int.Parse(tempMatch.Groups[1].Value);
                    deep = int.Parse(tempMatch.Groups[2].Value);
                    direction = (GeoDirection)Enum.Parse(typeof(GeoDirection), tempMatch.Groups[3].Value);
                }
            }
            catch (Exception exp)
            {
                throw new Exception("Robot command is not in correct format");
            }

            return (wide, deep, direction);
        }

        public static (uint, uint) ParsRoomInitCommand(string command)
        {
            uint wide = 0;
            uint deep = 0;

            try
            {
                string pattern = @"^(\d+)\s(\d+)$";
                Match tempMatch = Regex.Match(command, pattern);
                if (tempMatch != null && tempMatch.Success)
                {
                    wide = uint.Parse(tempMatch.Groups[1].Value);
                    deep = uint.Parse(tempMatch.Groups[2].Value);
                }
            }
            catch (Exception exp)
            {
                throw new Exception("Room command is not in correct format");
            }

            return (wide, deep);
        }

        public static List<char> ParsMoveRobotCommand(string command)
        {
            List<char> result = null;

            command = command.ToUpper();
            try
            {
                string pattern = @"^[LRF]+$";
                Match tempMatch = Regex.Match(command, pattern);
                if (tempMatch != null && tempMatch.Success)
                {
                    result = command.ToList();
                }
            }
            catch (Exception exp)
            {
                throw new Exception("Room command is not in correct format");
            }

            return result;
        }
    }
}
