using UnityEngine;
using UnityEngine.UI;

public class AttackCooldownUI : MonoBehaviour
{
    [Header("UI References")]
    public Image meleeCooldownImage;
    public Image rangedCooldownImage;
    public Image aoeCooldownImage;
    public Image shieldCooldownImage;

    //[Header("Optional Text Elements")]
    //public Text meleeCooldownText;
    //public Text rangedCooldownText;
    //public Text aoeCooldownText;
    //public Text shieldCooldownText;

    private MeleeAttack playerAttack;

    [Header("Visual Effects")]
    public ParticleSystem readyEffect;
    public Color readyColor = Color.green;
    public Color cooldownColor = Color.red;

    private void Start()
    {
        playerAttack = FindObjectOfType<MeleeAttack>();
        if (playerAttack == null)
        {
            Debug.LogError("Could not find MeleeAttack component in scene!");
        }

        // Initialize all cooldown images to full
        if (meleeCooldownImage != null) meleeCooldownImage.fillAmount = 0;
        if (rangedCooldownImage != null) rangedCooldownImage.fillAmount = 0;
        if (aoeCooldownImage != null) aoeCooldownImage.fillAmount = 0;
        if (shieldCooldownImage != null) shieldCooldownImage.fillAmount = 0;
    }

    private void Update()
    {
        UpdateMeleeCooldownUI();
        UpdateRangedCooldownUI();
        UpdateAoeCooldownUI();
        UpdateShieldCooldownUI();
    }

    private void UpdateMeleeCooldownUI()
    {
        if (playerAttack.IsAttacking)
        {
            // Melee attack is a duration rather than cooldown
            if (meleeCooldownImage != null)
                meleeCooldownImage.fillAmount = 1;

            //if (meleeCooldownText != null)
              //  meleeCooldownText.text = "Attacking!";
        }
        else
        {
            if (meleeCooldownImage != null)
                meleeCooldownImage.fillAmount = 0;

           // if (meleeCooldownText != null)
               // meleeCooldownText.text = "L Mouse";
        }
    }

    private void UpdateRangedCooldownUI()
    {
        if (!playerAttack.canShoot)
        {
            float cooldownProgress = 1 - (playerAttack.rangedCooldownTimer / playerAttack.rangedCooldown);

            if (rangedCooldownImage != null)
                rangedCooldownImage.fillAmount = cooldownProgress;

           // if (rangedCooldownText != null)
              //  rangedCooldownText.text = Mathf.Ceil(playerAttack.rangedCooldownTimer).ToString();

            if (rangedCooldownImage != null)
                rangedCooldownImage.color = Color.Lerp(readyColor, cooldownColor, 1 - cooldownProgress);
        }
        else
        {
            if (rangedCooldownImage != null)
                rangedCooldownImage.fillAmount = 0;

            //if (rangedCooldownText != null)
               // rangedCooldownText.text = "R Mouse";

            if (rangedCooldownImage != null && rangedCooldownImage.fillAmount > 0)
            {
                PlayReadyEffect(rangedCooldownImage);
            }
            if (rangedCooldownImage != null)
                rangedCooldownImage.color = readyColor;
        }
    }

    private void UpdateAoeCooldownUI()
    {
        if (!playerAttack.canUseAoe)
        {
            float cooldownProgress = 1 - (playerAttack.aoeCooldownTimer / playerAttack.aoeCooldown);

            if (aoeCooldownImage != null)
                aoeCooldownImage.fillAmount = cooldownProgress;

            //if (aoeCooldownText != null)
               // aoeCooldownText.text = Mathf.Ceil(playerAttack.aoeCooldownTimer).ToString();

            if (aoeCooldownImage != null)
                aoeCooldownImage.color = Color.Lerp(readyColor, cooldownColor, 1 - cooldownProgress);
        }
        else
        {
            if (aoeCooldownImage != null)
                aoeCooldownImage.fillAmount = 0;

            //if (aoeCooldownText != null)
                //aoeCooldownText.text = "Q";

            if (aoeCooldownImage != null && aoeCooldownImage.fillAmount > 0)
            {
                PlayReadyEffect(aoeCooldownImage);
            }
            if (aoeCooldownImage != null)
                aoeCooldownImage.color = readyColor;
        }
    }

    private void UpdateShieldCooldownUI()
    {
        if (!playerAttack.canUseShield)
        {
            float cooldownProgress = 1 - (playerAttack.shieldCooldownTimer / playerAttack.shieldCooldown);

            if (shieldCooldownImage != null)
                shieldCooldownImage.fillAmount = cooldownProgress;

           // if (shieldCooldownImage != null)
              //  shieldCooldownText.text = Mathf.Ceil(playerAttack.shieldCooldownTimer).ToString();

            if (shieldCooldownImage != null)
                shieldCooldownImage.color = Color.Lerp(readyColor, cooldownColor, 1 - cooldownProgress);
        }
        else
        {
            if (shieldCooldownImage != null)
                shieldCooldownImage.fillAmount = 0;

           // if (shieldCooldownText != null)
            //    shieldCooldownText.text = "E";

            if (shieldCooldownImage != null && shieldCooldownImage.fillAmount > 0)
            {
                PlayReadyEffect(shieldCooldownImage);
            }
            if (shieldCooldownImage != null)
                shieldCooldownImage.color = readyColor;
        }
    }
    private void PlayReadyEffect(Image image)
    {
        if (readyEffect != null && image != null)
        {
            readyEffect.transform.position = image.transform.position;
            readyEffect.Play();
        }
    }
}
