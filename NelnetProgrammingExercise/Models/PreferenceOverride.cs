using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    public class PreferenceOverride
    {
        public bool Like
        { get; set; }
        public string OverrideType
        { get; set; }
        public string WeightClass
        { get; set; }
        public PetClassification Classification { get; set; }
        public PetType PetType { get; set; }
    }
}
