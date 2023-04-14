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

    public static int ballCount;
    public static int ballThrowCount;
    IEnumerator BallThrowSystem()
    {
        while (true)
        {
            if (!Lock)
            {
                yield return new WaitForSeconds(.5f);
                if(ballThrowCount % 5 == 0 && ballThrowCount != 0)
                {
                    for(int i = 0; i < 2; i++)
                    {
                        ThrowBallandFix();
                    }
                    ballCount = 2;
                    ballThrowCount++;
                }
                else
                {
                    ThrowBallandFix();
                    ballThrowCount++;
                    ballCount = 1;
                }

                yield return new WaitForSeconds(.7f);

                RandomBasketPointIndex = Random.Range(0, basketPoints.Length - 1);
                Basket.transform.position = basketPoints[RandomBasketPointIndex].transform.position;
                Basket.SetActive(true);
                Lock = true;
                Invoke("CheckBall", 5);
            }
            else
            {
                yield return null;
            }
        }
    }
    void Start()
    {
        ballThrowCount = 0;
        ballCount = 0;
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
        if(ballCount == 1)
        {
            Lock = false;
            Basket.SetActive(false);
            CancelInvoke();
            ballCount--;
        }
        else
        {
            ballCount--;
        }
    }
    float giveAngle(float min, float max)
    {
        return Random.Range(min,max);
    }
    Vector3 givePosition(float angle)
    {
       return Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
    }
    void CheckBall()
    {
        if (Lock)
        {
            GetComponent<GameManager>().GameOver();
        }
    }

    void ThrowBallandFix()
    {
        Balls[activeBallIndex].transform.position = ballBase.transform.position;
        Balls[activeBallIndex].SetActive(true);
        Balls[activeBallIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(givePosition(giveAngle(70f, 110f)) * 750);
        if (activeBallIndex != Balls.Length - 1)
        {
            activeBallIndex++;
        }
        else
        {
            activeBallIndex = 0;
        }
    }
}
