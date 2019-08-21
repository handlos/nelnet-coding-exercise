using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    /* Per requirement #3, made all of the preferences (classification, type and weight) virtual so they could be overridable.
     * Derived classes could then override those preferences and perform additional behaviors as well.
     * 
     * Per requirement #4, added a virtual "GetOverride" method that returned a generic list of preference overrides, 
     * so derived subclasses can have an essentially limited number of overrides.
     */
    public class PersonModel
    {
        public string Name { get; set; }
        public virtual PetClassification PreferredClassification { get; set; }
        public virtual PetType PreferredType { get; set; }

        public virtual string PreferredPetWeightClass { get; set; }
        public virtual List<PreferenceOverride> GetOverrides()
        { return null; }
    }

    public class DogHater_TypeOverride : PersonModel
    {
        private List<PreferenceOverride> OList = new List<PreferenceOverride>();
        public override List<PreferenceOverride> GetOverrides()
        { return OList; }
        public override PetType PreferredType
        {
            get { return base.PreferredType; }

            set
            {
                PreferenceOverride p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Dog;
                OList.Add(p);
                base.PreferredType = value;
            }
        }
    }


    public class CatLover_TypeOverride : PersonModel
    {
        private List<PreferenceOverride> OList = new List<PreferenceOverride>();
        public override List<PreferenceOverride> GetOverrides()
        { return OList; }

        public override PetType PreferredType
        {
            get { return base.PreferredType; }

            set
            {
                PreferenceOverride p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = true;
                p.PetType = PetType.Cat;
                OList.Add(p);
                base.PreferredType = value;
            }
        }
    }


    public class OnlyLikesExtraSmallGoldFish_TypeAndWeightOverride : PersonModel
    {
        private List<PreferenceOverride> OList = new List<PreferenceOverride>();
        public override List<PreferenceOverride> GetOverrides()
        {
            return OList;
        }

        public override string PreferredPetWeightClass
        {
            get { return base.PreferredPetWeightClass; }
            set
            {
                PreferenceOverride p = new PreferenceOverride();
                p.OverrideType = "weight";
                p.Like = false;
                p.WeightClass = "Small";
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "weight";
                p.Like = false;
                p.WeightClass = "Medium";
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "weight";
                p.Like = false;
                p.WeightClass = "Large";
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "weight";
                p.Like = false;
                p.WeightClass = "Extra Large";
                OList.Add(p);
                base.PreferredPetWeightClass = value;
            }
        }

        public override PetType PreferredType
        {
            get { return base.PreferredType; }

            set
            {
                PreferenceOverride p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Dog;
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Betta;
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Canary;
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Cat;
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Parrot;
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Rat;
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Snake;
                OList.Add(p);
                p = new PreferenceOverride();
                p.OverrideType = "type";
                p.Like = false;
                p.PetType = PetType.Spider;
                OList.Add(p);
                base.PreferredType = value;
            }
        }
    }
}
