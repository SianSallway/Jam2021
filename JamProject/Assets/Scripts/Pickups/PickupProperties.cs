﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupProperties : MonoBehaviour
{
    //[Header("UI Items")]
    //[SerializeField] GameObject waterScoreTxt;
    //[SerializeField] GameObject nitroScoreTxt;
    //[SerializeField] GameObject healthScoreTxt;

    public enum PickupType
    {
        PICKUP_WATER,
        PICKUP_NITRO,
        PICKUP_ARMOUR,
        PICKUP_TIRES
    };

    public PickupType pickupType;
    PlayerController player;
    public float handlingScore;
   
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

                player.salvage += 1;
                //waterScoreTxt.GetComponent<TMPro.TextMeshProUGUI>().text = ": " + player.water.ToString();
                Destroy(gameObject);

                break;

            case PickupType.PICKUP_TIRES:

                player.salvage += 0.055f;
                Destroy(gameObject);

                break;

            case PickupType.PICKUP_NITRO:

                player.acceleratedSpeed += 0.1f;
                player.salvage += 0.06f;

                Destroy(gameObject);

                break;

            case PickupType.PICKUP_ARMOUR:

                player.salvage += 1.75f;
                Destroy(gameObject);

                break;
        }
    }
}