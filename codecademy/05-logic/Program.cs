using System;

public class SpaceExpedition
{
    public static void Main(string[] args){
        bool isAtmosphereBreathable = true;
        bool isGravityStable = false;
        bool resourcesSufficient = true;
        bool isHabitable = isAtmosphereBreathable && isGravityStable;
        Console.WriteLine(isHabitable);
        bool suitableForExpansion = isGravityStable || resourcesSufficient;
        Console.WriteLine(suitableForExpansion);
        int currentCrew = 5;
        int maxCrewCapacity = 10;
        bool canAcceptMoreCrew = currentCrew < maxCrewCapacity;
        Console.WriteLine(canAcceptMoreCrew); 
    }
}