using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] GameObject lastCheckpoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLastCheckpoint(GameObject checkPoint)
    {
        lastCheckpoint = checkPoint;
    }

    public void ActivateCheckpoint()
    {
        lastCheckpoint.GetComponent<Checkpoint>().ResetPlayer();
    }
}