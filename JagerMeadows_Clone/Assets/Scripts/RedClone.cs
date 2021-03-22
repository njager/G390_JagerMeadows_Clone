using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedClone : MonoBehaviour
{
    //public variables


    //private variables
    Rigidbody rB;
    Health health;
    [SerializeField] float speed;
    [SerializeField] int damage;

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
        if (collision.gameObject.CompareTag("BlueClone") || collision.gameObject.CompareTag("BlueBase"))
        {
            health = collision.gameObject.GetComponent<Health>();
            InvokeRepeating("DealDamage", 0f, 1f);
        }
    }

    void DealDamage()
    {
        health.TakeDamage(damage);
        Debug.Log("Red clone is dealing damage to blue clone!");
    }
}