using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    private PlayerHealthController healthController;
    
    void Start()
    {
        //healthController = FindFirstObjectByType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.gameObject.SetActive(false);
            //healthController.DamageToPlayer();
            PlayerHealthController.instance.DamageToPlayer();
        }
    }
}
