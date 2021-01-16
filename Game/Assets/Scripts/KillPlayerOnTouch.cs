using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Dog>() !=null)
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
}
