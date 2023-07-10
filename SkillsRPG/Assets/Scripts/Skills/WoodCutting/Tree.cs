using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Interactible
{
    public event System.Action<int> OnWoodCut;

    [SerializeField] private int xpGivenWhenCut;
    [SerializeField] private int requiredLevel;

    private int cutDelay = 4;
    private WCLevelSystem wCLevelSystem;
    
    private void Start() 
    {
        wCLevelSystem = FindObjectOfType<WCLevelSystem>();   
    }

    public override void Interact()
    {
        if (!hasInteracted)
        {
            hasInteracted = true;
            StartCoroutine(CutTreeRoutine());
        }
    }

    IEnumerator CutTreeRoutine()
    {
        // Delay between each tick of xp granted and wood harvested
        yield return new WaitForSeconds(cutDelay);
        hasInteracted = false;

        // Notify the WCLevelSystem about the wood cut
        OnWoodCut?.Invoke(xpGivenWhenCut);
        
        Debug.Log("Current woodcutting level: " + wCLevelSystem.GetLevelNumber());
    }
}
