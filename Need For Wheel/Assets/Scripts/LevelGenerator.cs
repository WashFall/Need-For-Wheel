using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelGenerator : MonoBehaviour
{
    public LevelSectionData[] levelSectionData;
    public LevelSectionData firstSection;

    private LevelSectionData previousSection;
    private Steering steering;

    public Vector3 spawnOrigin;

    private Vector3 spawnPosition;
    public int sectionsToSpawn = 10;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    SpawnLegalSection();
        //}
    }
    private void Start()
    {
        previousSection = firstSection;

        for (int i = 0; i < sectionsToSpawn; i++)
        {
            SpawnLegalSection();
        }

        steering = new Steering();
        steering.Ground.Enable();
        steering.Ground.Debug.performed += SpawnLegalSectionTrigger;
    }

    LevelSectionData PickNextSection()
    {
        List<LevelSectionData> legalSectionList = new List<LevelSectionData>();
        LevelSectionData nextSection = null;

        LevelSectionData.Direction nextRequiredDirection = LevelSectionData.Direction.North;

        switch (previousSection.exitDirection)
        {
            case LevelSectionData.Direction.North:
                nextRequiredDirection = LevelSectionData.Direction.South;
                spawnPosition = spawnPosition + new Vector3(0f, 0, previousSection.SectionSize.y);

                break;
            case LevelSectionData.Direction.East:
                nextRequiredDirection = LevelSectionData.Direction.West;
                spawnPosition = spawnPosition + new Vector3(previousSection.SectionSize.x, 0, 0);

                break;
            case LevelSectionData.Direction.South:
                nextRequiredDirection = LevelSectionData.Direction.North;
                spawnPosition = spawnPosition + new Vector3(0, 0, -previousSection.SectionSize.y);

                break;
            case LevelSectionData.Direction.West:
                nextRequiredDirection = LevelSectionData.Direction.East;
                spawnPosition = spawnPosition + new Vector3(-previousSection.SectionSize.x, 0, 0);

                break;
            default:
                break;
        }

        for (int i = 0; i < levelSectionData.Length; i++)
        {
            if (levelSectionData[i].entryDirection == nextRequiredDirection)
            {
                legalSectionList.Add(levelSectionData[i]);
            }
        }

        nextSection = legalSectionList[Random.Range(0, legalSectionList.Count)];

        return nextSection;
    }

    void SpawnLegalSection()
    {
        LevelSectionData sectionToSpawn = PickNextSection();

        GameObject objectFromSection = sectionToSpawn.levelSections[Random.Range(0, sectionToSpawn.levelSections.Length)];
        previousSection = sectionToSpawn;
        Instantiate(objectFromSection, spawnPosition + spawnOrigin, Quaternion.identity);

    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }

    void SpawnLegalSectionTrigger(InputAction.CallbackContext context)
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnLegalSection();
        }
    }
}
