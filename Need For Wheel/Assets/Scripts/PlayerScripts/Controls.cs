using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
