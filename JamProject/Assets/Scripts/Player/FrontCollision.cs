using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCollision : MonoBehaviour
{
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Raider")
        {
            DealDamage(other.gameObject, player.damage);
        }
    }

    public void DealDamage(GameObject obj, float damage)
    {
        obj.GetComponent<RaiderController>().TakeDamage(damage);
    }
}
