using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 10f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBoosterParticle;
    [SerializeField] ParticleSystem rightSideBoosterParticle;
    [SerializeField] ParticleSystem leftSideBoosterParticle;

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {   
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            RotateStop();
        }
    }

    private void StartThrusting()
    {
        rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        if (!mainBoosterParticle.isPlaying)
        {
            mainBoosterParticle.Play();
        }
    }

    private void StopThrusting()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        mainBoosterParticle.Stop();
    }

    private void RotateLeft()
    {
        ApplyRotation(1f);
        if (!rightSideBoosterParticle.isPlaying) rightSideBoosterParticle.Play();
    }

    private void RotateRight()
    {
        ApplyRotation(-1f);
        if (!leftSideBoosterParticle.isPlaying) leftSideBoosterParticle.Play();
    }

    private void RotateStop()
    {
        leftSideBoosterParticle.Stop();
        rightSideBoosterParticle.Stop();
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
