using UnityEngine;
using TMPro; 

public class HealthDisplay : MonoBehaviour
{
    [Header("Referanslar")]
    public PlayerHealth PlayerHealth; 
    public TMP_Text Health_text; 

    void Update()
    {
        
        if (PlayerHealth != null)
        {
            
            Health_text.text =  PlayerHealth.CurrentHealth.ToString() + "/" + PlayerHealth.maxHealth.ToString();
        }
    }
}