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
        targetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref speed, dampTime);
    }
}
