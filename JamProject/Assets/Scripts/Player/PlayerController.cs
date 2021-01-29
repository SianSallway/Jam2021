using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Stats")]
    
    public float speed;
    public float damage;
    public float health;
    public float water;
    public float handling;
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
        verticalMovement = new Vector3( 0, Input.GetAxis("Vertical"), 0);
        
        
        transform.position += verticalMovement * Time.deltaTime * speed;
        transform.position += horizontalMovement * Time.deltaTime * speed;

        //down
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= verticalMovement * Time.deltaTime * speed;

        }

        //down
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= verticalMovement * Time.deltaTime * speed;

        }

        //right
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position -= horizontalMovement * Time.deltaTime * speed;

        }
    }

    public void TakeDamage()
    {

    }
}