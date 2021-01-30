using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float speed;
    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody2D>();
        //rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * speed);

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        //transform.position  = (transform.position - targetPos) * Time.deltaTime * speed;
    }

    public void SetDirection(Vector3 tp)
    {
        //targetPos = tp;


        //Debug.Log("vel: " + rigidbody.velocity);
        //rigidbody.AddForce((Vector2)direction * speed);
    }
}