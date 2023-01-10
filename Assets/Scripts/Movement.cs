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
            // ���� ��� �� �� �ֵ��� ���� ������ ���� ȸ���� ���
            rigidBody.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime * rotationThrust);
            // ���� ���� �� ���� ������ ���� ȸ���� Ǯ���ش�. 
            rigidBody.freezeRotation = false;
        }
    }
}
