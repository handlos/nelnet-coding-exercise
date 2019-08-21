using NelnetProgrammingExercise.Models;
using System;
using System.Linq;

namespace NelnetProgrammingExercise
{
    class Program
    {
        private static PersonModel[] People;
        private static PetModel[] Pets;

        #region Initialization

        private static void SetupObjects()
        {
            People = new PersonModel[]
            {
                new DogHater_TypeOverride()
                {
                    Name = "Dalinar Dislikes Dogs",
                    PreferredPetWeightClass="Medium",
                    PreferredClassification = PetClassification.Mammal,
                    PreferredType = PetType.Snake
                },
                new CatLover_TypeOverride()
                {
                    Name = "Dalinar Loves Cats",
                    PreferredPetWeightClass="Small",
                    PreferredClassification = PetClassification.Bird,
                    PreferredType = PetType.Snake
                },
                new PersonModel()
                {
                    Name = "Dalinar",
                    PreferredPetWeightClass="Medium",
                    PreferredClassification = PetClassification.Mammal,
                    PreferredType = PetType.Snake
                },
                new PersonModel()
                {
                    Name = "Kaladin",
                    PreferredPetWeightClass="Extra Small",
                    PreferredClassification = PetClassification.Bird,
                    PreferredType = PetType.Goldfish
                },
                new OnlyLikesExtraSmallGoldFish_TypeAndWeightOverride()
                {
                    Name = "Paladin",
                    PreferredPetWeightClass="Extra Small",
                    PreferredClassification = PetClassification.Bird,
                    PreferredType = PetType.Goldfish
                }
            };

            //Note: Added the weight as a double for the pets in the "PetModel" array for requirement #1.
            Pets = new PetModel[]
            {
                new PetModel()
                {
                    Name = "Garfield",
                    Weight = 20.0,
                    Classification = PetClassification.Mammal,
                    Type = PetType.Cat,
                },
                new PetModel()
                {
                    Name = "Odie",
                    Weight = 15.0,
                    Classification = PetClassification.Mammal,
                    Type = PetType.Dog
                },
                new PetModel()
                {
                    Name = "Peter Parker",
                    Weight=0.5,
                    Classification = PetClassification.Arachnid,
                    Type = PetType.Spider
                },
                new PetModel()
                {
                    Name = "Kaa",
                    Weight=25.0,
                    Classification = PetClassification.Reptile,
                    Type = PetType.Snake
                },
                new PetModel()
                {
                    Name = "Nemo",
                    Weight=0.5,
                    Classification = PetClassification.Fish,
                    Type = PetType.Goldfish
                },
                new PetModel()
                {
                    Name = "Alpha",
                    Weight=0.1,
                    Classification = PetClassification.Fish,
                    Type = PetType.Betta
                },
                new PetModel()
                {
                    Name = "Splinter",
                    Weight=0.5,
                    Classification = PetClassification.Mammal,
                    Type = PetType.Rat
                },
                new PetModel()
                {
                    Name = "Coco",
                    Weight=6.0,
                    Classification = PetClassification.Bird,
                    Type = PetType.Parrot
                },
                new PetModel()
                {
                    Name = "Tweety",
                    Weight=0.05,
                    Classification = PetClassification.Bird,
                    Type = PetType.Canary
                }
            };
        }

        #endregion

        /* Requirement #5 stated the following:
                *  Pet decisions shall be made using the following hierarchy (1 overrides 2, 2 overrides 3, etc.):
                      1) Type
                      2) Classification
                      3) Weight
                      4) Default Type/Classification/Weight on person object

                * So order to satisfy this requirement, the "IsGood" method was adjusted to make decisions first based in a 4, 3, 2, 1 order.
                * First it will check the default behavior, then will evaluate the pet status based on weight overrides, then classification, and finally, type. 
                */
        private static string IsGood(PersonModel person, PetModel pet)
        {
            //Defaulting the status to "bad"...assuming this person would not want a pet unless proven otherwise.
            string PetStatus = "bad";

            //Confirming if the weight of the animal matches the preferred weight class of the person.
            bool WeightMatch = false;
            if (person.PreferredPetWeightClass.ToLower() == WeightClass.GetClass(pet.Weight).ToLower())
            { WeightMatch = true; }

            //Confirming whether or not the preferred classification of the pet matches the person's preference.
            bool PreferredClassificationMatch = false;
            if (person.PreferredClassification == pet.Classification)
            { PreferredClassificationMatch = true; }

            //Confirming whether or not the preferred pet type matches the person's preferences.
            bool PreferredPetTypeMatch = false;
            if (person.PreferredType == pet.Type)
            { PreferredPetTypeMatch = true; }

            //Default Type/Classification/Weight decision made based on the person's preferences, similar to the original version of the code.
            //If one of the condition matches (weight, classification, or type), it can be considered a potential good pet.
            if (WeightMatch || PreferredClassificationMatch || PreferredPetTypeMatch)
            { PetStatus = "good"; }

            //Checks to see if the person object (or derived class of it) has any overrides.
            //If any exist, it does 3 "for" loops through all the available overrides, checking for weight, then class, then type.
            if (person.GetOverrides() != null && person.GetOverrides().Count > 0)
            {

                foreach (PreferenceOverride ov in person.GetOverrides())
                {
                    if (ov.OverrideType == "weight")
                    {
                        if (WeightClass.GetClass(pet.Weight) == ov.OverrideType)
                        {
                            if (ov.Like)
                            { PetStatus = "good"; }
                            else if (!ov.Like) { PetStatus = "bad"; }
                        }
                    }
                }

                foreach (PreferenceOverride ov in person.GetOverrides())
                {
                    if (ov.OverrideType == "classification")
                    {
                        if (pet.Classification == ov.Classification)
                        {
                            if (ov.Like)
                            { PetStatus = "good"; }
                            else if (!ov.Like) { PetStatus = "bad"; }
                        }
                    }

                }

                foreach (PreferenceOverride ov in person.GetOverrides())
                {
                    if (ov.OverrideType == "type")
                    {
                        if (pet.Type == ov.PetType)
                        {
                            if (ov.Like)
                            { PetStatus = "good"; }
                            else if (!ov.Like) { PetStatus = "bad"; }
                        }
                    }

                }

            }

            //Returns the pet status (i.e. "good" or "bad")
            return PetStatus;
        }

        static void Main(string[] args)
        {
            SetupObjects();

            foreach(PersonModel person in People) {
                Console.WriteLine(string.Format("Pets for {0}:", person.Name));

                foreach(PetModel pet in Pets)
                {
                    Console.WriteLine(string.Format("{0} would be a {1} pet.", pet.Name, IsGood(person, pet)));
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
