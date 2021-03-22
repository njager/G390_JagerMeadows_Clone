using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueClone : MonoBehaviour
{
    //public variables
    public float speed;
    public int damage;

    //private variables
    Rigidbody rB;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rB.velocity = new Vector3(speed, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedClone") || collision.gameObject.CompareTag("RedBase"))
        {
            health = collision.gameObject.GetComponent<Health>();
            InvokeRepeating("DealDamage", 0f, 1f);
        }
    }

    void DealDamage()
    {
        health.TakeDamage(damage);
        Debug.Log("Blue clone is dealing damage to red clone!");
    }
}
