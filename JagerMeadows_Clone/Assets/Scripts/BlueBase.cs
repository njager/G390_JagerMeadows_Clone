using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BlueBase : MonoBehaviour
{
    //public variables
    public TextMeshProUGUI blueHealthText;

    //private variables 
    [SerializeField] int damage;
    int blueHealth;
    Health health;
    public AudioClip eggclip;
    private AudioSource basesource;
    public GameObject redwin;
    [SerializeField] GameObject EndImage;

    [SerializeField] GameObject redpost;
    
    [SerializeField] GameObject redend;
    

    // Start is called before the first frame update
    void Start()
    {
        basesource = gameObject.GetComponent<AudioSource>();
        blueHealth = GetComponent<Health>().health;
        SetText();
    }

    private void FixedUpdate()
    {
        blueHealth = GetComponent<Health>().health;
        
        SetText();

        if (blueHealth <= 0)
        {
            redwin.SetActive(true);
            EndImage.SetActive(true);

            redpost.SetActive(true);
            redend.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedClone"))
        {
            health = collision.gameObject.GetComponent<Health>();
            SetText();
            InvokeRepeating("DealDamage", 0f, 1f);
        }
    }

    void SetText()
    {
        blueHealthText.text = "Blue Health = " + blueHealth.ToString();
    }

    void DealDamage()
    {
        if (health.health > 0)
        {
            health.TakeDamage(damage);
            Debug.Log("Blue base is dealing damage to red clone!");
            SetText();
            Eggsound();
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
