using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basehealth : MonoBehaviour
{
    //variables
    public int health;


    //function that when called removes health
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        
    }
}