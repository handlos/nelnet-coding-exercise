using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    /* Function Name: GetClass
     * Desc: For requirement #2, created a basic method to return the weight class/range that corresponded to the pet's weight, in addition to an "Unclassified" status, 
     * in the unlikely event that some weight is somehow given as zero (or less). 
        Extra Small: 0 < x <= 1.0
        Small: 1.0 < x <= 5.0
        Medium: 5.0 < x <= 15.0
        Large: 15.0 < x <= 30.0
        Extra Large: 30.0 < x
        */
    public static class WeightClass
    {
        public static string GetClass(double Weight)
        {
            string WeightClass = "";

            if (0 < Weight && Weight <= 1.0)
            {WeightClass = "Extra Small";}

            else if (1.0 < Weight && Weight <= 5.0)
            {WeightClass = "Small";}

            else if (5.0 < Weight && Weight <= 15.0)
            { WeightClass = "Medium"; }

            else if (15.0 < Weight && Weight <= 30.0)
            { WeightClass = "Large";  }

            else if (Weight > 30.0)
            { WeightClass = "Extra Large"; }

            else
            { WeightClass = "Unclassified"; }

            return WeightClass;
        }
    }
}
