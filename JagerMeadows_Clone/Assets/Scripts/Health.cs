using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //variables
    public int health;
    [SerializeField] GameObject body;
    [SerializeField] Transform explosion; 

    //function that when called removes health
    public void TakeDamage(int damageAmount)
    {
        //this.GameObject
        health -= damageAmount;

        if (health <= 0 && gameObject.tag == "BlueBase" || health <= 0 && gameObject.tag == "RedBase")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
            Destroy(exploder, 2.0f);
        }
        else if (health <= 0)
        {
            GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
            Destroy(exploder, 2.0f);
            gameObject.GetComponent<Collider>().enabled = false;
            body.gameObject.SetActive(false);
            Destroy(gameObject, 3);
        }
    }
}
