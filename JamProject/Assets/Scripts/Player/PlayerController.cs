using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Stats")]
    
    public float speed;
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
        
        
        //transform.position += verticalMovement * Time.deltaTime * speed;
        //transform.position += horizontalMovement * Time.deltaTime * speed;

      
        if (verticalMovement.y != 0)
        {
            //transform.position += verticalMovement * Time.deltaTime * speed;
            Vector3 movement = transform.TransformVector(Vector3.up) * verticalMovement.y * Time.deltaTime * speed;
            transform.position = transform.position + movement;
        }

        //down
        if (Input.GetAxis("Horizontal") != 0)
        {
            //transform.position -= verticalMovement * Time.deltaTime * speed;
            //gameObject.transform.localRotation = new Vector3();

            //float turn = turnValue * turnSpeed * Time.deltaTime;
            gameObject.transform.eulerAngles += new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, -turnValue);
            //Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            //rigidbody.MoveRotation(rigidbody.rotation * turn);

        }

        //right
        if (Input.GetKeyDown(KeyCode.D))
        {
            //transform.position -= horizontalMovement * Time.deltaTime * speed;
            gameObject.transform.eulerAngles += new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, -turnValue);

        }
    }

    public void TakeDamage()
    {

    }
}