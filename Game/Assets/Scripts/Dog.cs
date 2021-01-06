using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private Animator animator;
    private bool isHopping;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //If the W key is pressed
        if (Input.GetKeyDown(KeyCode.W) && !isHopping) 
        {

            float zDifference = 0;
            if(transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, zDifference));

            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        //If the A key is pressed
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));

            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        //If the D key is pressed
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));

            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        //If the S key is pressed
        else if (Input.GetKeyDown(KeyCode.S) && !isHopping)
        {
            MoveCharacter(new Vector3(-1, 0, 0));

            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);
    }

    public void FinishHop()
    {
        isHopping = false;
    }

    //If the player goes past 24f on the z-axis (left)
    //insert code...

    //If the player goes past -24f on the z-axis (right)
    //insert code...
}
