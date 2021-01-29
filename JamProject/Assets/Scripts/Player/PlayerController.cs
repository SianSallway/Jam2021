using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Stats")]
    
    public float speed;
    public float defaultSpeed;
    public float acceleratedSpeed;
    public float turnSpeed;
    public float damage;
    public float health;
    public float water;
    public float handling;
    float turnValue;
    Rigidbody2D rigidbody;
    Vector3 horizontalMovement;
    Vector3 verticalMovement;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        turnValue = Input.GetAxis("Horizontal");
        verticalMovement = new Vector3( 0, Input.GetAxis("Vertical"), 0);

        //constantly moving at a default speed
        Vector3 movement = transform.TransformVector(Vector3.up) * Time.deltaTime * speed;
        transform.position = transform.position + movement;

        //speed increased to an accelerated Speed
        if (verticalMovement.y != 0)
        {
            speed = acceleratedSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }

        //turning
        if (Input.GetAxis("Horizontal") != 0)
        {
            gameObject.transform.eulerAngles += new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, -turnValue);

        }
    }

    public void TakeDamage()
    {

    }
}