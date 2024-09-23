using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Checkpoint[] allCheckpoints;

    private Checkpoint activeCheckpoint;
    public Vector3 respawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        allCheckpoints = FindObjectsByType<Checkpoint>(FindObjectsSortMode.None);
        
        foreach(Checkpoint cp in allCheckpoints)
        {
            cp.checkpointManage = this;
        }

        respawnPosition = FindFirstObjectByType<PlayerController>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateAllCheckpoints()
    {
        foreach(Checkpoint cp in allCheckpoints)
        {
            cp.DeactivateCheckpoint();
        }
    }

    public void SetActiveCheckpoint(Checkpoint newActiveCheckpoint)
    {
        DeactivateAllCheckpoints();
        activeCheckpoint = newActiveCheckpoint;

        respawnPosition = newActiveCheckpoint.transform.position;
    }
}
