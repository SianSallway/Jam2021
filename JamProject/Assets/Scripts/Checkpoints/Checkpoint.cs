using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    public CheckpointManager checkpointManager;

    // Start is called before the first frame update
    void Start()
    {
        checkpointManager = GameObject.Find("CheckpointManager").GetComponent<CheckpointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPlayer()
    {
        Instantiate(player, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            checkpointManager.SetLastCheckpoint(gameObject);
        }
    }
}