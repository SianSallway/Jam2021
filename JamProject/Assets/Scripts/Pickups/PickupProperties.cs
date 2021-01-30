using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupProperties : MonoBehaviour
{
    public enum PickupType
    {
        PICKUP_WATER,
        PICKUP_SPIKES,
        PICKUP_NITRO,
        PICKUP_ARMOUR,
        PICKUP_TIRES
    };

    public PickupType pickupType;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(pickupType)
        {
            case PickupType.PICKUP_WATER:

                player.water += 1;

                break;

            case PickupType.PICKUP_TIRES:

                player.handling += 0.1f;
                player.gameObject.GetComponent<Rigidbody2D>().angularDrag -= 1;

                break;

            case PickupType.PICKUP_SPIKES:

                player.damage += 1;

                break;

            case PickupType.PICKUP_NITRO:

                player.acceleratedSpeed += 0.1f;

                break;

            case PickupType.PICKUP_ARMOUR:

                player.RestoreHealth();

                break;
        }
    }
}