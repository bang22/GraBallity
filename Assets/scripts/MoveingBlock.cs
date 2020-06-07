using UnityEngine;
using System.Collections;

public class MoveingBlock : MonoBehaviour
{
    [SerializeField]
    private Transform point1;
    [SerializeField]
    private Transform point2;
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed = 0.1f;

    private int dir = 1;//포인트 1,2 

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPoint = Vector2.zero;
        if (dir == 1) { targetPoint = point1.position; }
        if (dir == 2) { targetPoint = point2.position; }

        target.position = Vector2.MoveTowards(target.position, targetPoint, speed);

        if (target.position == point1.position) dir = 2;
        if (target.position == point2.position) dir = 1;
    }
}
