using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiderController : MonoBehaviour
{
    public enum State
    {
        STATE_RAM,
        STATE_TRAVEL
    }

    public State raiderState = State.STATE_TRAVEL;
    public float health;
    public float damage;
    public float speed;
    public float ramSpeed;
    public float travelSpeed;

    public bool contactMade;

    LineRenderer line;
    PlayerController player;
    public float ramTimer;
    public float dt;
    public Vector3 ramDirection;
    float rotationAngle;

    [SerializeField] DilemmaManager dilemmaManager;

    // Start is called before the first frame update
    void Start()
    {
        //line = gameObject.GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        dilemmaManager = GameObject.Find("DilemmaTrigger").GetComponent<DilemmaManager>();

        //travelSpeed = Random.Range(0.1f, 0.2f);
        ramSpeed = Random.Range(0.3f, 0.6f);
        ramTimer = Random.Range(6, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if(!dilemmaManager.finalReached)
        {
            dt += Time.deltaTime;
            Vector3 forwardMovement = transform.TransformVector(Vector3.up) * Time.deltaTime * speed;
            transform.position = transform.position + forwardMovement;
            speed = player.speed;

            if (dt >= ramTimer)
            {
                raiderState = State.STATE_RAM;
            }

            switch (raiderState)
            {
                case State.STATE_RAM:

                    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

                    ramDirection = (player.transform.position - transform.position).normalized;
                    rotationAngle = Mathf.Atan2(ramDirection.x, ramDirection.y) * Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, 0, -rotationAngle);

                    speed += ramSpeed;

                    if (Vector3.Distance(transform.position, player.transform.position) == 3 || contactMade)
                    {
                        raiderState = State.STATE_TRAVEL;
                        contactMade = false;
                        dt = 0;
                    }

                    break;

                case State.STATE_TRAVEL:

                    speed = player.speed;
                    transform.eulerAngles = new Vector3(0, 0, 0);

                    break;
            }
        }
        

    }

    public void TakeDamage(float damageTaken)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            health -= damageTaken;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(raiderState == State.STATE_RAM && other.gameObject.tag == "Player" || raiderState == State.STATE_RAM && other.transform.parent != null && other.transform.parent.gameObject.tag == "Player")
        {
            contactMade = true;
            DealDamage(other.gameObject, damage);
        }
    }

    public void DealDamage(GameObject obj, float damageValue)
    {
        obj.GetComponent<PlayerController>().TakeDamage(damage);
    }

}