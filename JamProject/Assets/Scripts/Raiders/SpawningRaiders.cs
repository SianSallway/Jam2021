using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningRaiders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRaider(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
}