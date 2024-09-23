using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance;

    private void Awake()
    {
        instance = this;
    }
    private PlayerController player;
    public float respawnDelay = 2f;
    public int currentLives = 3;
    
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();

        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        //player.transform.position = FindFirstObjectByType<CheckPointManager>().respawnPosition;

        //PlayerHealthController.instance.AddHealth(PlayerHealthController.instance.maxHealth);
        player.gameObject.SetActive(false);
        player.rB.velocity = Vector2.zero;
        currentLives--;

        if (currentLives > 0)
        {
            StartCoroutine(RespawnCoroutine());
        }
        else
        {
            currentLives = 0;

            StartCoroutine(GameOverScreen());
        }
        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = FindFirstObjectByType<CheckPointManager>().respawnPosition;
        PlayerHealthController.instance.AddHealth(PlayerHealthController.instance.maxHealth);
        player.gameObject.SetActive(true);
    }

    public IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(respawnDelay);

        if (UIController.instance != null)
        {
            UIController.instance.ShowGameOver();
        }
    }
}
