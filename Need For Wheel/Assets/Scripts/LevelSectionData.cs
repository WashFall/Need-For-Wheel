using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelSectionData")]
public class LevelSectionData : ScriptableObject
{
    public enum Direction
    {
        North, East, South, West
    }

    public Vector3 SectionSize = new Vector3(10f, 10f, 10f);

    public GameObject[] levelSections;
    public Direction entryDirection;
    public Direction exitDirection;

    public void ApplySize()
    {
        foreach (var levelSection in levelSections)
        {
            levelSection.transform.localScale = SectionSize;
        }
    }
}
