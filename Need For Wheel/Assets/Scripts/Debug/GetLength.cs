using UnityEngine;

// This was used to measure the length of a map piece made outside of Unity
public class GetLength : MonoBehaviour
{
    public GameObject mapPiece;

    private void Start()
    {
        Debug.Log(mapPiece.transform.GetChild(0).GetComponent<MeshRenderer>().bounds.size);
    }
}
