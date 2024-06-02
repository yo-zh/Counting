using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMovement : MonoBehaviour
{
    private Rigidbody conveyorRb;

    [SerializeField] 
    private float speed;

    void Start()
    {
        conveyorRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = conveyorRb.position;
        conveyorRb.position += transform.forward * -speed * Time.deltaTime; // Negative speed to move forward locally
        conveyorRb.MovePosition(pos);
    }
}
