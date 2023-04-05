using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject Line;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> touchPosition;

    void Update()
    {
        
    }

    void createLine()
    {
        Line = Instantiate(LinePrefab,Vector2.zero,Quaternion.identity);
        lineRenderer = Line.GetComponent<LineRenderer>();
        edgeCollider = Line.GetComponent<EdgeCollider2D>();
    }
}
