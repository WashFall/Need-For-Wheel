using UnityEngine;

// An abstract class for the movement controls, which enables easy swapping between movement options
public abstract class Controls : MonoBehaviour
{
    public PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    public virtual void Forward(Vector3 inputVector) { }
    public virtual void Backward(Vector3 inputVector) { }
    public virtual void Left(Vector3 inputVector) { }
    public virtual void Right(Vector3 inputVector) { }
}
