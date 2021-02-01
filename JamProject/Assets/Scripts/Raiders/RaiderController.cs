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
    public bool returned;
    public bool blocked;
    public bool turned;


     LineRenderer line;
    PlayerController player;
    public float ramTimer;
    public float dt;
    public Vector3 ramDirection;
    public Vector3 returnDirection;
    float rotationAngle;
    AudioSource audioSource;
    //[SerializeField]List<AudioClip> clips;

    [SerializeField] DilemmaManager dilemmaManager;

    // Start is called before the first frame update
    void Start()
    {
        //line = gameObject.GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        dilemmaManager = GameObject.Find("DilemmaTrigger").GetComponent<DilemmaManager>();
        audioSource = gameObject.GetComponent<AudioSource>();

        //travelSpeed = Random.Range(0.1f, 0.2f);
        ramSpeed = Random.Range(0.3f, 0.6f);
        ramTimer = Random.Range(6, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if(!dilemmaManager.dilemmaReached)
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

                    returned = false;

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

                    /*if(!returned && !blocked)
                    {
                        transform.eulerAngles = new Vector3(0, 0, Random.Range(-50, 50));

                        if (Vector3.Distance(transform.position, player.transform.position) >= 10)
                        {
                            returned = true;
                        }
                    }
                    else if(returned && !blocked )
                    {
                        transform.eulerAngles = new Vector3(0, 0, player.transform.eulerAngles.z);

                    }*/

                    if(!blocked)
                    {
                        transform.eulerAngles = new Vector3(0, 0, player.transform.eulerAngles.z);

                    }



                    break;
            }
        }       

    }

    public void TakeDamage(float damageTaken)
    {
        if (health <= 0)
        {
            audioSource.Play();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<HazardProperties>() != null)
        {
            blocked = true;
            Turn();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<HazardProperties>() != null)
        {
            blocked = false;
            turned = false;
        }
    }

    IEnumerator TurnRaider()
    {
        yield return new WaitForSeconds(5);

        float rotation = Random.Range(-50, 50);
        transform.eulerAngles = new Vector3(0, 0, rotation);

        yield break;
    }

    void Turn()
    {
        if(!turned)
        {
            float rotation = Random.Range(-50, 50);
            float turnValue = transform.eulerAngles.z + 70;
            transform.eulerAngles = new Vector3(0, 0, turnValue);
            turned = true;
        }


    }

    public void DealDamage(GameObject obj, float damageValue)
    {
        obj.GetComponent<PlayerController>().TakeDamage(damage);
    }

}