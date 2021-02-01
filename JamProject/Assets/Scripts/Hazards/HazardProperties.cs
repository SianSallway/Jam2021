using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardProperties : MonoBehaviour
{
    public enum HazardType
    {
        HAZARD_CACTUS,
        HAZARD_BOLDER,
        HAZARD_OIL
    };
    
    public HazardType hazardType;
    public float cactusDamage;
    public float bolderDamage;
    [SerializeField] Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
        if(hazardType != HazardType.HAZARD_OIL)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (hazardType)
        {
            case HazardType.HAZARD_BOLDER:

                if (other.gameObject.tag == "Player")
                {
                    audioSource.Play();

                    DealDamage(other.gameObject, bolderDamage);
                    other.gameObject.GetComponent<PlayerController>().isBlocked = true;


                }

                break;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        switch (hazardType)
        {
            case HazardType.HAZARD_BOLDER:

                if (other.gameObject.tag == "Player")
                {
                    Unblock();

                }

                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (hazardType)
        {
            case HazardType.HAZARD_OIL:

                if (other.gameObject.tag == "Player")
                {
                    float rotation = Random.Range(-50, 50);
                    other.gameObject.GetComponent<PlayerController>().spinOut = true;
                    other.gameObject.transform.eulerAngles = new Vector3(0, 0, rotation);
                    other.gameObject.GetComponent<PlayerController>().spinOut = false;
                }
                break;                           
                               
            case HazardType.HAZARD_CACTUS:

                if (other.gameObject.tag == "Player")
                {
                    audioSource.Play();
                    animator.SetTrigger("Explode");
                    //Animation anim = an.GetComponent<Animation>();

                    Debug.Log("Collided w/ player");
                    other.gameObject.GetComponent<PlayerController>().SlowSpeed();
                    DealDamage(other.gameObject, cactusDamage);

                    Invoke("RemoveSlowness", 0.2f);
                }

                break;
        }
    }

    public void DealDamage(GameObject obj, float damage)
    {
        obj.GetComponent<PlayerController>().TakeDamage(damage);
    }

    void RemoveSlowness()
    {
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.RestoreSpeed(player.isSlowed); 
        
    }
    void Unblock()
    {
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.isBlocked = false;
        player.speed = player.defaultSpeed;

    }
}