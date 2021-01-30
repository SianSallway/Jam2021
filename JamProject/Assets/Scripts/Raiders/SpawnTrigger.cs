using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnpoints;
    [SerializeField] GameObject raider;


    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            spawnpoints.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            foreach(GameObject point in spawnpoints)
            {
                point.GetComponent<SpawningRaiders>().SpawnRaider(raider);
            }
        }
    }
}