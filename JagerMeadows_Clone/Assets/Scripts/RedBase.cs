using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    [SerializeField] GameObject EndImage;

    [SerializeField] GameObject bluepost;
    
    [SerializeField] GameObject blueend;

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
        SetText();

        if (redHealth <= 0)
        {
            bluewin.SetActive(true);
            EndImage.SetActive(true);

            bluepost.SetActive(true);
            blueend.SetActive(true);
        }
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

    void DealDamage()
    {
        if (health.health > 0)
        {
            health.TakeDamage(damage);
            Debug.Log("Red base is dealing damage to blue clone!");
            SetText();
            Eggsound();
        }
        else if (health.health < 0)
        {
            Debug.Log("Stopped dealing damage");
            CancelInvoke("DealDamage");
        }
    }

    public void Eggsound()
    {
        basesource.PlayOneShot(eggclip);
    }
}
