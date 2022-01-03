using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private Rigidbody rigidbodyComponent;
    private float horizontalInput;
    private float verticallInput;
    public int thrustFactor = 50000;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticallInput = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        //print(horizontalInput);
        //print(verticallInput);
        Quaternion deltaRotation = Quaternion.Euler(transform.up * horizontalInput * Time.fixedDeltaTime * 50);//define delta rotation factor

        rigidbodyComponent.MoveRotation(rigidbodyComponent.rotation * deltaRotation);//rotate the car as per the user input

        rigidbodyComponent.AddForce(transform.forward * verticallInput * thrustFactor);//add a forward thrust


    }
}
