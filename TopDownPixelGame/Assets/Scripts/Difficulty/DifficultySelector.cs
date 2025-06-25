using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{

    /*
    private EnemyHealth enemyHealth;
    private MeleeAttack attack;
    private PlayerController playerController;
    //[SerializeField] PlayerHealth playerHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        attack = GetComponent<MeleeAttack>();
        playerController = GetComponent<PlayerController>();
    }
    public void Normal()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        attack = GetComponent<MeleeAttack>();
        playerController = GetComponent<PlayerController>();

        enemyHealth.MaxHealth = 6f;
        enemyHealth.bowDam = 1;

        attack.aoeDamage = 0.5f;
        attack.damage = 2f;
        playerController.enemyDMG = 2f;

    }

    public void Easy()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        attack = GetComponent<MeleeAttack>();
        playerController = GetComponent<PlayerController>();

        enemyHealth.MaxHealth = 5f;
        enemyHealth.bowDam = 2;

        attack.aoeDamage = 1f;
        attack.damage = 3f;
        playerController.enemyDMG = 1f;
    }
    */
    public void SelectEasy()
    {
        DifficultyManager.Instance.SetDifficulty(GameDifficulty.Easy);
        // Load your next scene
        SceneManager.LoadScene("Scene 1");
    }

    public void SelectNormal()
    {
        DifficultyManager.Instance.SetDifficulty(GameDifficulty.Normal);
        // Load your next scene
        SceneManager.LoadScene("Scene 1");
    }

}
