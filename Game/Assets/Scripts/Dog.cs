using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    
    private Animator animator;
    private bool isHopping;
    private int score;
    private Coroutine still;
    int tries = 3;
    private void Start()
    {
        animator = GetComponent<Animator>();
        still = StartCoroutine(Standstill());
    }

    private void FixedUpdate()
    {
        score++;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
        //If the W key is pressed
        if (Input.GetKeyDown(KeyCode.W) && !isHopping) 
        {

            float zDifference = 0;
            if(transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
             MoveCharacter(new Vector3(1, 0, zDifference));
             StopCoroutine(still);
             still = StartCoroutine(Standstill());

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
            transform.position = (transform.position + new Vector3(-1, 0, 0));

            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        //If the Space key is pressed
        else if (Input.GetKeyDown(KeyCode.Space) && !isHopping)
        {
            if(tries > 0)
            {
                MoveCharacter(new Vector3(2, 0, 0));

                var audioSource = GetComponent<AudioSource>();
                audioSource.Play();
                tries--;
            } 

        } 
    }

    IEnumerator Standstill()
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene("Menu");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<MovingObject>() !=null)
        {
            if (collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrain(false, transform.position);
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
