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
    bool Lock;

    IEnumerator BallThrowSystem()
    {
        while (true)
        {
            if (!Lock)
            {
                yield return new WaitForSeconds(.5f);
                Balls[activeBallIndex].transform.position = ballBase.transform.position;
                Balls[activeBallIndex].SetActive(true);
                float angle = Random.Range(70f, 110f);
                Vector3 position = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
                Balls[activeBallIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(position * 750);
                if (activeBallIndex != Balls.Length - 1)
                {
                    activeBallIndex++;
                }
                else
                {
                    activeBallIndex = 0;
                }

                yield return new WaitForSeconds(.7f);

                RandomBasketPointIndex = Random.Range(0, basketPoints.Length - 1);
                Basket.transform.position = basketPoints[RandomBasketPointIndex].transform.position;
                Basket.SetActive(true);
                Lock = true;
                Invoke("CheckBall", 3);
            }
            else
            {
                yield return null;
            }
        }
    }
    void Start()
    {
        
    }
    public void stopThrowing()
    {
        StopAllCoroutines();
    }
    public void playGame()
    {
        StartCoroutine(BallThrowSystem());
    }

    public void Continue()
    {
        Lock = false;
        Basket.SetActive(false);
        CancelInvoke();
    }
  
    void CheckBall()
    {
        if (Lock)
        {
            GetComponent<GameManager>().GameOver();
        }
    }
}
