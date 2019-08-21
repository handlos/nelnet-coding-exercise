# Nelnet Coding Exercise

Please fork this repository and enhance it with the following requirements:
#Update (8/21/2019): Code comments have been added in addition to the notes below for the assignment.

## Requirement #1
Pets shall have a weight.  Use the following data for the existing test objects:

- Garfield: 20.0
- Odie: 15.0
- Peter Parker: 0.5
- Kaa: 25.0
- Nemo: 0.5
- Alpha: 0.1
- Splinter: 0.5
- Coco: 6.0
- Tweety: 0.05
## Note: Added these values to the "PetModel" array in the "SetupObjects" method in "Program.cs", and added a "Weight" value for the "PetModel.cs", and added "PreferredPetWeightClass" as a label/string in the PersonModel.

## Requirement #2
Person shall have a prefered weight.  Weight classes are defined as:

- Extra Small: 0 < x <= 1.0
- Small: 1.0 < x <= 5.0
- Medium: 5.0 < x <= 15.0
- Large: 15.0 < x <= 30.0
- Extra Large: 30.0 < x
## Note: Created a method called "GetClass" in a "WeightClass.cs" file that can be called to return the range a given pet's weight corresponds to, and added 

Use the following data for the existing test objects:

- Dalinar: Medium
- Kaladin: Extra Small
## Note: Updated the "PersonModel" array in the "SetupObjects" method in Program.cs to account for this.

## Requirement #3
All preferences (classification, type, weight) shall be overridable.
## Note: Set all of the preference properties in "PersonModel" as virtual so they could be overridable.

## Requirement #4
A person shall be able to have unlimited number of overrides
## Note: added a virtual "GetOverride" method that returned a generic list of preference overrides, so derived subclasses can have an essentially limited number of overrides. Created a "PreferenceOverride" object that gets defined  by a derived class as it is being initialized.

## Requirement #5
Pet decisions shall be made using the following hierarchy (1 overrides 2, 2 overrides 3, etc.):


1. Type
2. Classification
3. Weight
4. Default Type/Classification/Weight on person object

For example, given Person A below:

```
{
  Name: 'Person A',
  PreferredClassification: PetClassification.Mammal,
  PreferredType: PetType.Cat
}
```

And Pet object:

```
{
  Name = "Odie",
  Classification = PetClassification.Mammal,
  Type = PetType.Dog
}
```

This would return as a good pet match because the user's preferred classification matches the pet's classification.  However, if Person A was opposed to dogs, we would want to be able to add an override for PetType.Dog so that this would no longer be a good match. 

## Note: To accomplish this, modified the "IsGood" method to first check the default preferences, and if any of them come back as "true", then change the pet status to "good". Then check if any overrides exist (first weight, then classification, and type), and then loop through each and change the pet status to "good" or "bad" as the override dictates. To prove the overrides work for someone who was opposed to dogs, created a "DogHater_TypeOverride" that would change any decision to "bad" if a dog was involved, and created a "Dalinar Dislikes Dogs" person to test it out. Also created a more extreme case of "OnlyLikesExtraSmallGoldFish_TypeAndWeightOverride", where it overrode any pet that wasn't an extra small goldfish, so that would be the only pet for a person named "Paladin".


