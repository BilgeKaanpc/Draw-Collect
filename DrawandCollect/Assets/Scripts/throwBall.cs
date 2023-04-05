using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwBall : MonoBehaviour
{
    [SerializeField] private GameObject[] Balls;
    [SerializeField] private GameObject ballBase;
    [SerializeField] private GameObject Basket;
    [SerializeField] private GameObject[] basketPoints;
    int activeBallIndex;
    int RandomBasketPointIndex;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Balls[activeBallIndex].transform.position = ballBase.transform.position;
            Balls[activeBallIndex].SetActive(true);
            float angle = Random.Range(70f,110f);
            Vector3 position = Quaternion.AngleAxis(angle,Vector3.forward) * Vector3.right;
            Balls[activeBallIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(position * 750);
            if(activeBallIndex != Balls.Length - 1)
            {
                activeBallIndex++;
            }
            else
            {
                activeBallIndex = 0;
            }
            Invoke("createBasket",.5f);
        }
    }

    void createBasket()
    {
        RandomBasketPointIndex = Random.Range(0, basketPoints.Length - 1);
        Basket.transform.position = basketPoints[RandomBasketPointIndex].transform.position;
        Basket.SetActive(true);
    }
}