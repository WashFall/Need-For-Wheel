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
    public FinalDestination finalSection;

    public float segmentRotation;

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
            SpawnLegalSection(i);
        }

        SpawnFinalSection();

        steering = new Steering();
        steering.Ground.Enable();
        steering.Ground.Debug.performed += SpawnLegalSectionTrigger;
    }

    LevelSectionData PickNextSection(int sectionId)
    {
        List<LevelSectionData> legalSectionList = new List<LevelSectionData>();
        LevelSectionData nextSection = null;

        LevelSectionData.Direction nextRequiredDirection = LevelSectionData.Direction.North;

        switch (previousSection.exitDirection)
        {
            case LevelSectionData.Direction.North:
                nextRequiredDirection = LevelSectionData.Direction.South;
                //spawnPosition = spawnPosition + new Vector3(0f, 0, previousSection.SectionSize.y);

                break;
            //case LevelSectionData.Direction.East:
            //    nextRequiredDirection = LevelSectionData.Direction.West;
            //    //spawnPosition = spawnPosition + new Vector3(previousSection.SectionSize.x, 0, 0);

            //    break;
            //case LevelSectionData.Direction.South:
            //    nextRequiredDirection = LevelSectionData.Direction.North;
            //    // spawnPosition = spawnPosition + new Vector3(0, 0, -previousSection.SectionSize.y);

            //    break;
            //case LevelSectionData.Direction.West:
            //    nextRequiredDirection = LevelSectionData.Direction.East;
            //    //spawnPosition = spawnPosition + new Vector3(-previousSection.SectionSize.x, 0, 0);

            //    break;
            default:
                break;
        }

        if (sectionId == sectionsToSpawn - 1) 
        {
            for (int i = 0; i < levelSectionData.Length; i++)
            {
                if (levelSectionData[i].entryDirection == nextRequiredDirection && levelSectionData[i].exitDirection == LevelSectionData.Direction.North)
                {
                    nextSection = levelSectionData[i];
                }
            }

            if (nextSection == null)
            {
                Debug.LogError($"No section found with required directions from {nextRequiredDirection} to North");
            }
        }
        else
        {
            for (int i = 0; i < levelSectionData.Length; i++)
            {
                if (levelSectionData[i].entryDirection == nextRequiredDirection)
                {
                    legalSectionList.Add(levelSectionData[i]);
                }
            }

            nextSection = legalSectionList[Random.Range(0, legalSectionList.Count)];
        }

        return nextSection;
    }

    void SpawnLegalSection(int sectionId)
    {
        LevelSectionData sectionToSpawn = PickNextSection(sectionId);

        switch (previousSection.exitDirection)
        {
            case LevelSectionData.Direction.North:
                Vector3 segmentShift;
                if (sectionId == 0)
                {
                    segmentShift = new Vector3(
                        0f,
                        -(previousSection.SectionSize.y * 0.5f) * Mathf.Sin(segmentRotation * Mathf.Deg2Rad),
                        previousSection.SectionSize.y * 0.5f + sectionToSpawn.SectionSize.y * 0.5f * Mathf.Cos(segmentRotation * Mathf.Deg2Rad)
                    );
                }
                else
                {
                    segmentShift = new Vector3(
                        0f,
                        -(previousSection.SectionSize.y * 0.5f + sectionToSpawn.SectionSize.y * 0.5f) * Mathf.Sin(segmentRotation * Mathf.Deg2Rad),
                        (previousSection.SectionSize.y * 0.5f + sectionToSpawn.SectionSize.y * 0.5f) * Mathf.Cos(segmentRotation * Mathf.Deg2Rad)
                    );
                }

                spawnPosition += segmentShift;
                break;
                //case LevelSectionData.Direction.West:
                //    spawnPosition += new Vector3(-previousSection.SectionSize.x * 0.5f - sectionToSpawn.SectionSize.x * 0.5f, 0f, 0f);
                //    break;
                //case LevelSectionData.Direction.South:
                //    spawnPosition += new Vector3(0f, 0f, -previousSection.SectionSize.y * 0.5f - sectionToSpawn.SectionSize.y * 0.5f);
                //    break;
                //case LevelSectionData.Direction.East:
                //    spawnPosition += new Vector3(previousSection.SectionSize.x * 0.5f + sectionToSpawn.SectionSize.x * 0.5f, 0f, 0f);
                //    break;
        }

        GameObject objectFromSection = sectionToSpawn.levelSections[Random.Range(0, sectionToSpawn.levelSections.Length)];
        previousSection = sectionToSpawn;
        var rotation = Quaternion.Euler(segmentRotation, 0f, 0f);
        var spawnedSection = Instantiate(objectFromSection, spawnPosition + spawnOrigin, rotation);
        spawnedSection.transform.localScale = new Vector3(sectionToSpawn.SectionSize.x / 100f, 1f, sectionToSpawn.SectionSize.y / 100f);
    }

    public void UpdateSpawnOrigin(Vector3 originDelta)
    {
        spawnOrigin = spawnOrigin + originDelta;
    }

    void SpawnLegalSectionTrigger(InputAction.CallbackContext context)
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnLegalSection(0);
        }
    }

    void SpawnFinalSection()
    {
        var finalSectionInstance = 
            Instantiate(finalSection, spawnPosition + new Vector3(0f, -previousSection.SectionSize.y * 0.5f * Mathf.Sin(segmentRotation * Mathf.Deg2Rad), previousSection.SectionSize.y * 0.5f * Mathf.Cos(segmentRotation * Mathf.Deg2Rad)), Quaternion.identity);
        finalSectionInstance.RotateSlope(segmentRotation);
    }
}
