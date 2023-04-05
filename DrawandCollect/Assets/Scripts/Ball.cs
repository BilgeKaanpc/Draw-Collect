using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("basket"))
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("gameOver")) 
        {
            gameObject.SetActive(false);
        }
    }
}
