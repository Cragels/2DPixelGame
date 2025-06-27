using UnityEngine;

public class DifficultyAdjuster : MonoBehaviour
{
    private void Start()
    {
        ApplyDifficultySettings();
    }

    private void ApplyDifficultySettings()
    {
        var manager = DifficultyManager.Instance;


        if (TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
            enemyHealth.MaxHealth = manager.CurrentDifficulty switch
            {
                GameDifficulty.Easy => manager.easyEnemyHealth,
                GameDifficulty.Normal => manager.normalEnemyHealth,
                GameDifficulty.Hard => manager.hardEnemyHealth,
                _ => manager.normalEnemyHealth
            };
        }

        if (TryGetComponent<MeleeAttack>(out var meleeAttack))
        {
            meleeAttack.damage = manager.CurrentDifficulty switch
            {
                GameDifficulty.Easy => manager.easyPlayerDamage,
                GameDifficulty.Normal => manager.normalPlayerDamage,
                GameDifficulty.Hard => manager.hardPlayerDamage,
                _ => manager.normalPlayerDamage
            };

            meleeAttack.aoeDamage = manager.CurrentDifficulty switch
            {
                GameDifficulty.Easy => manager.easyAOEDamage,
                GameDifficulty.Normal => manager.normalAOEDamage,
                GameDifficulty.Hard => manager.hardAOEDamage,
                _ => manager.normalAOEDamage
            };
        }

        if (TryGetComponent<PlayerController>(out var playerController))
        {
            playerController.enemyDMG = manager.CurrentDifficulty switch
            {
                GameDifficulty.Easy => manager.easyEnemyDamage,
                GameDifficulty.Normal => manager.normalEnemyDamage,
                GameDifficulty.Hard => manager.hardEnemyDamage,
                _ => manager.normalEnemyDamage
            };
        }

        if (TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.MaxHealth = manager.CurrentDifficulty switch
            {
                GameDifficulty.Easy => manager.easyPlayerHealth,
                GameDifficulty.Normal => manager.normalPlayerHealth,
                GameDifficulty.Hard => manager.hardPlayerHealth,
                _ => manager.normalPlayerHealth
            };
            playerHealth.ResetHealth();
        }
    }




    /*if (TryGetComponent<EnemyHealth>(out var enemyHealth))
    {
        enemyHealth.MaxHealth = manager.CurrentDifficulty == GameDifficulty.Easy
            ? manager.easyEnemyHealth
            : manager.normalEnemyHealth;
    }

    if (TryGetComponent<MeleeAttack>(out var meleeAttack))
    {
        meleeAttack.damage = manager.CurrentDifficulty == GameDifficulty.Easy
            ? manager.easyPlayerDamage
            : manager.normalPlayerDamage;

        meleeAttack.aoeDamage = manager.CurrentDifficulty == GameDifficulty.Easy
            ? manager.easyAOEDamage
            : manager.normalAOEDamage;
    }

    if (TryGetComponent<PlayerController>(out var playerController))
    {
        playerController.enemyDMG = manager.CurrentDifficulty == GameDifficulty.Easy
            ? manager.easyEnemyDamage
            : manager.normalEnemyDamage;
    }

    if (TryGetComponent<PlayerHealth>(out var playerHealth))
    {
        playerHealth.MaxHealth = manager.CurrentDifficulty == GameDifficulty.Easy
            ? manager.easyPlayerHealth
            : manager.normalPlayerHealth;
        playerHealth.ResetHealth();
    }


}*/
}
