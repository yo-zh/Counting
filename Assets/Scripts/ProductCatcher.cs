using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductCatcher : MonoBehaviour
{
    [SerializeField]
    private float verticalInput;
    [SerializeField]
    private float horizontalInput;

    private Vector3 startPos;
    private Vector3 moveDirection;
    void Start()
    {
        startPos = transform.position;
        transform.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector3(0, verticalInput * 5, horizontalInput * 2.5f);


        if(verticalInput != 0 || horizontalInput != 0)
        {
            transform.position = startPos + moveDirection;
            transform.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            transform.position = startPos;            
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Product"))
        {
            collision.gameObject.SetActive(false);
            Counter.SharedInstance.DecreaseCount();
        }
        else if (collision.gameObject.CompareTag("BadProduct"))
        {
            collision.gameObject.SetActive(false);

        }
    }
}
