using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Line;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> touchPositionList;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            createLine();

        }
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(touchPosition,touchPositionList[^1]) > .1f)
            {
                UpdateLine(touchPosition);
            }
        }
    }

    void createLine()
    {
        Line = Instantiate(LinePrefab,Vector2.zero,Quaternion.identity);
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
}
