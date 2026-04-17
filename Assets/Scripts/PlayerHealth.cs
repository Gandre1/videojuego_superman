using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public UIManager uiManager;    public float invulnerabilityTime = 2f;

    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip deathSound;
    private bool isInvulnerable = false;

    private SpriteRenderer sr;

    public ScoreManager scoreManager;

    void Start()
    {
        currentLives = maxLives;
        sr = GetComponent<SpriteRenderer>();
        uiManager.UpdateLives(currentLives);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud") && !isInvulnerable)
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

    void TakeDamage()
    {
        currentLives--;

        Debug.Log("Vidas: " + currentLives);
        
        uiManager.UpdateLives(currentLives);

        if (currentLives <= 0)
        {
            audioSource.PlayOneShot(deathSound);
            Die();
            return;
        }
        
        audioSource.PlayOneShot(hitSound);

        StartCoroutine(Invulnerability());
  
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        float elapsed = 0f;

        while (elapsed < invulnerabilityTime)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }

        sr.enabled = true;
        isInvulnerable = false;
    }

    void Die()
    {
        Debug.Log("GAME OVER");

        Time.timeScale = 0f;
        uiManager.ShowGameOver();
    }
}