using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatUI : MonoBehaviour
{
    [SerializeField] private GameObject Grey;
    [SerializeField] private GameObject Panel;

    public TextMeshProUGUI timer;
    public float duration = 1f;
    private float currentTime;

    private MeleeAttack meleeAttack;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Grey");

            GreyOut();
            //CountDownText();   
        }
    }

    void CountDownText()
    {


        timer.text = Mathf.Ceil(currentTime).ToString();
    }

    void GreyOut()
    {
        Grey.SetActive(true);
        Panel.SetActive(true);
        
        //new WaitForSeconds(duration);

        Grey.SetActive(false);
        Panel.SetActive(false);
    }
}
