using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactible
{
    PlayerManager playerManager;
    CharacterStats thisCharacterStats;

    void Start() 
    {
        playerManager = PlayerManager.instance;
        thisCharacterStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        // Attack the enemy

        CharacterCombat playerCombat = playerManager.playerReference.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(thisCharacterStats);
        }
    }
}
