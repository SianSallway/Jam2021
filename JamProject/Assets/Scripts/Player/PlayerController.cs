using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Stats")]
    
    public float speed;
    public float defaultSpeed;
    public float acceleratedSpeed;
    public float damage;
    public float health;
    public float maxHealth;
    public float water;
    public float handling;
    public CheckpointManager checkpointManager;
    bool isPressed;
    bool isSlowed;
    public bool spinOut;
    float turnValue;
    Rigidbody2D rigidbody;
    Vector3 horizontalMovement;
    Vector3 verticalMovement;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        checkpointManager = GameObject.Find("CheckpointManager").GetComponent<CheckpointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //handling = Input.GetAxis("Horizontal");
        verticalMovement = new Vector3( 0, Input.GetAxis("Vertical"), 0);

        //constantly moving at a default speed
        if (!isSlowed)
        {
            Vector3 movement = transform.TransformVector(Vector3.up) * Time.deltaTime * speed;
            transform.position = transform.position + movement;


            //speed increased to an accelerated Speed
            if (verticalMovement.y != 0 && isPressed == false)
            {
                //Mathf.Lerp(speed, acceleratedSpeed, Time.deltaTime);
                speed = acceleratedSpeed;
            }
            else
            {
                speed = defaultSpeed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                isPressed = true;
            }
            else
            {
                isPressed = false;
            }
        }

        //turning
        if(!spinOut)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    gameObject.transform.eulerAngles += new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, handling);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    gameObject.transform.eulerAngles += new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, -handling);
                }

            }
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if(health <= 0)
        {
            checkpointManager.ActivateCheckpoint();
            Destroy(gameObject);
        }
        else
        {
            health -= damageTaken;
        }
    }
    public void DealDamage(GameObject obj, float damage)
    {
        obj.GetComponent<RaiderController>().TakeDamage(damage);
    }

    public void RestoreHealth()
    {
        health = maxHealth;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void RestoreSpeed()
    {
        speed = defaultSpeed;
        isSlowed = false;
        Debug.Log("New Speed: " + speed);
    }

    public void SlowSpeed()
    {
        speed /= 2;
        isSlowed = true;
        Debug.Log("New Speed: " + speed);
    }

}