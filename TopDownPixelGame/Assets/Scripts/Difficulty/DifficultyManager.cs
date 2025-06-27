using UnityEngine;

public enum GameDifficulty { Easy, Normal,Hard }

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }

    public GameDifficulty CurrentDifficulty { get; private set; } = GameDifficulty.Normal;

    [Header("Easy Mode Settings")]
    public float easyEnemyHealth = 5f;
    public float easyEnemyDamage = 1f;
    public float easyPlayerDamage = 3f;
    public float easyAOEDamage = 1f;
    public float easyPlayerHealth = 10f;

    [Header("Normal Mode Settings")]
    public float normalEnemyHealth = 6f;
    public float normalEnemyDamage = 2f;
    public float normalPlayerDamage = 2f;
    public float normalAOEDamage = 0.5f;
    public float normalPlayerHealth = 8f;


    [Header("Hard Mode Settings")]
    public float hardEnemyHealth = 8f;
    public float hardEnemyDamage = 3f;
    public float hardPlayerDamage = 1f;
    public float hardAOEDamage = 0.25f;
    public float hardPlayerHealth = 6f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficulty(GameDifficulty difficulty)
    {
        CurrentDifficulty = difficulty;
    }
}
