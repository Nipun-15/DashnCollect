using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickups : MonoBehaviour
{
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (CollectibleManager.instance != null)
            {
                CollectibleManager.instance.GetCollectible(amount);

                Destroy(gameObject);
                            
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
