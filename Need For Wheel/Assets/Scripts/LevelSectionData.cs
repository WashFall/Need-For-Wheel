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

    public Vector3 SectionSize = new Vector3(10f, 0, 10f);

    public GameObject[] levelSections;
    public Direction entryDirection;
    public Direction exitDirection;

}
