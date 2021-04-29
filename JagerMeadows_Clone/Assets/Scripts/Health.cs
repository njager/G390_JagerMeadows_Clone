using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //variables
    public int health;

    //function that when called removes health
    public void TakeDamage(int damageAmount)
    {
        //this.GameObject
        health -= damageAmount;

        if (health <= 0 && gameObject.tag == "BlueBase" || health <= 0 && gameObject.tag == "RedBase")
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
