using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCLevelSystem : MonoBehaviour
{
    [SerializeField] private List<int> xpTable;
    private int level = 0;
    private int experience = 0;
    private int experienceToNextLevel = 40; // TODO: transform it into a list

    private void Start()
    {
        // Encontre todos os objetos Tree na cena e remova a inscrição do evento OnWoodCut
        Tree[] trees = FindObjectsOfType<Tree>();
        foreach (Tree tree in trees)
        {
            tree.OnWoodCut += HandleWoodCut;
        }
    }

    private void OnDestroy()
    {
        // Encontre todos os objetos Tree na cena e remova a inscrição do evento OnWoodCut
        Tree[] trees = FindObjectsOfType<Tree>();
        foreach (Tree tree in trees)
        {
            tree.OnWoodCut -= HandleWoodCut;
        }
    }

    private void HandleWoodCut(int xpGiven)
    {
        AddExperience(xpGiven);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            // Ganho de experiência suficiente para subir de nível
            level++;
            experience -= experienceToNextLevel;
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }
}
