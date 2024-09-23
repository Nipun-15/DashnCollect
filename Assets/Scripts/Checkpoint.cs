using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isActive;

    [HideInInspector][SerializeField]
    public CheckPointManager checkpointManage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isActive == false)
        {
            checkpointManage.SetActiveCheckpoint(this);
            isActive = true;
        }
    }
    public void DeactivateCheckpoint()
    {
        isActive = false;
    }
}
