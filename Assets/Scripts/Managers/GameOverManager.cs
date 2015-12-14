using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;

    Animator animator;
    public float restartTimer;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            animator.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if(restartTimer >= restartDelay )
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
