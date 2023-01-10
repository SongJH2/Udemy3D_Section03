using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;

    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed SPACE");
            rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        }
    }

    void ProcessRotation()
    {   
        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Pressed A - Rotating Left");
            ApplyRotation(1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Pressed D - Rotating Right");
            ApplyRotation(-1f);
        }

        void ApplyRotation(float rotationThisFrame)
        {
            // 수동 제어를 할 수 있도록 물리 엔진에 의한 회전을 잠금
            rigidBody.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime * rotationThrust);
            // 수동 제어 후 물리 엔진에 의한 회전을 풀어준다. 
            rigidBody.freezeRotation = false;
        }
    }
}
