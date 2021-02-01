using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupProperties : MonoBehaviour
{
    [Header("UI Items")]
    [SerializeField] GameObject salvageTxt;
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
    AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        salvageTxt = GameObject.Find("Salvage_Count");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();

        switch (pickupType)
        {
            case PickupType.PICKUP_WATER:

                player.salvage += 1;
                salvageTxt.GetComponent<Text>().text = player.salvage.ToString() + "/80";
      
                Destroy(gameObject);

                break;

            case PickupType.PICKUP_TIRES:

                player.salvage += 1;
                salvageTxt.GetComponent<Text>().text = player.salvage.ToString() + "/80";

                Destroy(gameObject);

                break;

            case PickupType.PICKUP_NITRO:

                player.acceleratedSpeed += 1;
                salvageTxt.GetComponent<Text>().text = player.salvage.ToString() + "/80";
                Destroy(gameObject);

                break;

            case PickupType.PICKUP_ARMOUR:

                player.salvage += 1;
                salvageTxt.GetComponent<Text>().text = player.salvage.ToString() + "/80";
                Destroy(gameObject);

                break;
        }
    }
}