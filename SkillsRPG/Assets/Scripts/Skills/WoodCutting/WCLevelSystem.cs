using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCLevelSystem : MonoBehaviour
{
    private int level = 0;
    private int experience = 0;
    private int experienceToNextLevel = 40; //TODO transform to a list

    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            //* Experience enough to level up
            level++;
            experience -=experienceToNextLevel;     // put the experience to 0 when level up
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }
}
