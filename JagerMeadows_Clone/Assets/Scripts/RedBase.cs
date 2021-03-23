using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedBase : MonoBehaviour
{
    //public variables
    public TextMeshProUGUI redHealthText;

    //private variables 
    [SerializeField] int damage;
    int redHealth;
    Health health;
    public AudioClip eggclip;
    private AudioSource basesource;
    public GameObject bluewin;

    // Start is called before the first frame update
    void Start()
    {
        basesource = gameObject.GetComponent<AudioSource>();
        redHealth = GetComponent<Health>().health;
        SetText();
    }

    private void FixedUpdate()
    {
        redHealth = GetComponent<Health>().health;
        //SetText();
        


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueClone"))
        {
            health = collision.gameObject.GetComponent<Health>();
            SetText();
            InvokeRepeating("DealDamage", 0f, 1f);
        }
    }

    void SetText()
    {
        redHealthText.text = "Red Health = " + redHealth.ToString();
    }

    void Ending()
    {
        if (redHealth == 1)
        {
            bluewin.SetActive(true);
        }
    }

    void DealDamage()
    {
        if (health.health > 0)
        {
            health.TakeDamage(damage);
            Debug.Log("Red base is dealing damage to blue clone!");
            SetText();
            Eggsound();
            Ending();
        }
        
        else
        {
            CancelInvoke("DealDamage");
        }
    }

    public void Eggsound()
    {
        basesource.PlayOneShot(eggclip);
    }
}
