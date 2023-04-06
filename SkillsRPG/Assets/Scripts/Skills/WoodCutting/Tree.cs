using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Interactible
{
    WCLevelSystem wCLevelSystem;

    [SerializeField] private int xpGivenWhenCut;
    [SerializeField] private int requiredLevel;

    private int cutDelay = 4;
    
    void Awake()
    {
        wCLevelSystem = FindObjectOfType<WCLevelSystem>();
    }

    public override void Interact()
    {
        StartCoroutine(DelayBetweenCut());
    }

    IEnumerator DelayBetweenCut()
    {
        //* Delay between each tick of xp granted and wood harvested
        wCLevelSystem.AddExperience(xpGivenWhenCut);
        Debug.Log(wCLevelSystem.GetLevelNumber());
        hasInteracted = true;
        yield return new WaitForSeconds(cutDelay);
        hasInteracted = false;
    }
}
