using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    public Vector2 targetPos;
    public Vector2 speed;
    public float dampTime;

    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector2(10, 10);
        Debug.Log("Speed: " + speed);

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        Debug.Log("Speed: " + speed);

        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref speed, dampTime);
    }

    void Move()
    {

    }
}
