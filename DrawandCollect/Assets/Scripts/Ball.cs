using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("basket"))
        {
            gameObject.SetActive(false);
            _GameManager.Continue(transform.position);
        }
        else if (collision.gameObject.CompareTag("gameOver")) 
        {
            gameObject.SetActive(false);
            _GameManager.GameOver();
        }
    }
}
