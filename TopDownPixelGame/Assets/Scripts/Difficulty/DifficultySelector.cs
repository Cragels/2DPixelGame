using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown difficultyDropdown;

    private void Start()
    {
        // Set up the dropdown options
       // difficultyDropdown.ClearOptions();
        //difficultyDropdown.AddOptions(new List<string> { "Easy", "Normal", "Hard" });

        // Set default value based on current difficulty
        difficultyDropdown.value = (int)DifficultyManager.Instance.CurrentDifficulty;

        // Add listener for when the dropdown value changes
        difficultyDropdown.onValueChanged.AddListener(OnDifficultySelected);
    }

    private void OnDifficultySelected(int index)
    {
        // Convert the dropdown index to GameDifficulty enum
        GameDifficulty selectedDifficulty = (GameDifficulty)index;
        DifficultyManager.Instance.SetDifficulty(selectedDifficulty);
    }

    public void StartGame()
    {
        // Load your game scene
        SceneManager.LoadScene("Scene 1");
    }

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

    public void SelectHard()
    {
        DifficultyManager.Instance.SetDifficulty(GameDifficulty.Hard);
        SceneManager.LoadScene("Scene 1");
    }
    */
}
