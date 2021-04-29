using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    //variables
    public int health;
    [SerializeField] GameObject baseBox;

    //function that when called removes health
    public void TakeDamage(int damageAmount)
    {
        //this.GameObject
        health -= damageAmount;

        if (health <= 0)
        {
            baseBox.gameObject.SetActive(false);
        }
    }
}
