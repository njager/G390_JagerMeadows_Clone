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

    // Start is called before the first frame update
    void Start()
    {
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

    void DealDamage()
    {
        if (health.health > 0)
        {
            health.TakeDamage(damage);
            Debug.Log("Red base is dealing damage to blue clone!");
            SetText();
        }
        else
        {
            CancelInvoke("DealDamage");
        }
    }
}
