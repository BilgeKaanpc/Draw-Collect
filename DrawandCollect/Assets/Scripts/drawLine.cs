using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class drawLine : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Line;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> touchPositionList;
    public TMP_Text drawCountText;

    public List<GameObject> Lines;
    bool canDraw;
    int DrawRule;
    private void Start()
    {
        DrawRule = 3;
        canDraw = false;
        drawCountText.text = DrawRule.ToString();
    }
    void Update()
    {
        if(canDraw && DrawRule !=0) {

            if (Input.GetMouseButtonDown(0))
            {
                createLine();

            }
            if (Input.GetMouseButton(0))
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(touchPosition, touchPositionList[^1]) > .1f)
                {
                    UpdateLine(touchPosition);
                }
            }
        }
        if(Lines.Count != 0 && DrawRule != 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                DrawRule--;
                drawCountText.text = DrawRule.ToString();
            }
        }

    }

    void createLine()
    {
        Line = Instantiate(LinePrefab,Vector2.zero,Quaternion.identity);
        Lines.Add(Line);
        lineRenderer = Line.GetComponent<LineRenderer>();
        edgeCollider = Line.GetComponent<EdgeCollider2D>();
        touchPositionList.Clear();
        touchPositionList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        touchPositionList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0,touchPositionList[0]);
        lineRenderer.SetPosition(1,touchPositionList[1]);
        edgeCollider.points = touchPositionList.ToArray();
    }

    void UpdateLine(Vector2 touchPosition)
    {
        touchPositionList.Add(touchPosition);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,touchPosition);
        edgeCollider.points = touchPositionList.ToArray();
    }


    public void Continue()
    {
        if(throwBall.ballCount == 0)
        {
            foreach (var item in Lines)
            {
                Destroy(item.gameObject);
            }
            Lines.Clear();
            DrawRule = 3;
            drawCountText.text = DrawRule.ToString();
        }

    }

    public void stopDrawing()
    {
        canDraw = false;
    }
    public void startDrawing()
    {
        DrawRule = 3;
        canDraw = true;
    }
}
