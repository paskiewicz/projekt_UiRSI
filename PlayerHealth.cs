using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // startowe zycie
    public int currentHealth;                                   // aktyalne zycie
    public Slider healthSlider;                                 // health bar
    public Image damageImage;                                   // migawka
                                
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


    
    MovementScript playerMovement;                              
  //  PlayerShooting playerShooting;                              
    bool isDead;                                              
    bool damaged;                                             


    void Awake()
    {
        
        currentHealth = startingHealth;
    }


    void Update()
    {
         if (damaged)
        {
           
            damageImage.color = flashColour;
            print("atak");
        }
      
        else
        {
        
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

      
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
     
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
           
            Death();
        }
    }


    void Death()
    {
       isDead = true;
     //  playerMovement.enabled = false;
       
    }
}