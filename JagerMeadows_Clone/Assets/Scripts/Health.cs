using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //variables
    public int health;
    [SerializeField] GameObject body;
    [SerializeField] Transform explosion;
    [SerializeField] Material originalmaterial;
    [SerializeField] Material redmaterial;
    private float _flashSpeed = 0.1f;
    private float _lengthOfTimeToFlash = 0.02f;
    [SerializeField] GameObject duckmesh;
    [SerializeField] AudioClip[] sqeaks;
    private AudioSource a_source;

    //function that when called removes health

    private void Start()
    {
        a_source = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        duckmesh.GetComponent<MeshRenderer>().material = originalmaterial; 
    }
    
    public void TakeDamage(int damageAmount)
    {
        //this.GameObject
        health -= damageAmount;
        StartCoroutine(Flash(this._lengthOfTimeToFlash, this._flashSpeed));
        int selection = Random.Range(0, sqeaks.Length);
        a_source.PlayOneShot(sqeaks[selection]);


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
            Destroy(gameObject, 1);
        }
    }

    IEnumerator Flash(float time, float intervalTime)
    {
        float elapsedTime = 0f;
        int index = 0;
        while (elapsedTime < time)
        {
            duckmesh.GetComponent<MeshRenderer>().material = redmaterial;
            

            elapsedTime += Time.deltaTime;
            index++;
            yield return new WaitForSeconds(intervalTime);
        }

        if (elapsedTime >= time)
        {
            duckmesh.GetComponent<MeshRenderer>().material = originalmaterial;
        }
    }
}
