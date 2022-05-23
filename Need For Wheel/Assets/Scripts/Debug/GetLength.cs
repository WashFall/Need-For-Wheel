using UnityEngine;

public class GetLength : MonoBehaviour
{
    public GameObject mapPiece;

    private void Start()
    {
        Debug.Log(mapPiece.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size);
    }
}
