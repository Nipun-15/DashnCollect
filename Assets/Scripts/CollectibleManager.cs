using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int collectibleCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCollectible(int amount)
    {
        collectibleCount += amount;

        if(UIController.instance != null)
        {
            UIController.instance.UpdateCollectibles(collectibleCount);
        }
    }

}
