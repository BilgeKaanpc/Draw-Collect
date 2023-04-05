using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private throwBall _ThrowBall;
    [SerializeField] private drawLine _DrawLine;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Continue()
    {
        _ThrowBall.Continue();
        _DrawLine.Continue();
    }
    public void GameOver()
    {

    }
}
