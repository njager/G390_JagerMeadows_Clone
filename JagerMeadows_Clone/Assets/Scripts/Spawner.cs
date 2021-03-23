using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    //public variables
    public float blueStock;
    public float redStock;
    public float blueGrowthRate;
    public float redGrowthRate;
    public TextMeshProUGUI blueStockText;
    public TextMeshProUGUI redStockText;

    //private variables
    [SerializeField] int regularCloneCost;
    [SerializeField] int heavyCloneCost;
    [SerializeField] int speedCloneCost;
    [SerializeField] private List<Transform> blueCloneList;
    [SerializeField] private List<Transform> redCloneList;
    [SerializeField] private List<Transform> blueSpawnList;
    [SerializeField] private List<Transform> redSpawnList;
    Transform chosenBlueClone;
    Transform chosenRedClone;
    Vector3 chosenBlueSpawn;
    Vector3 chosenRedSpawn;
    int blueCloneIndex = 0;
    int redCloneIndex = 0;
    int blueSpawnIndex = 0;
    int redSpawnIndex = 0;
    bool blueHasUpgraded = false;
    bool redHasUpgraded = false;

    public GameObject rnormalass;
    public GameObject bnormalass;
    public GameObject rspeedyboi;
    public GameObject bspeedyboi;
    public GameObject rGOOSE;
    public GameObject bGOOSE;

    public GameObject b1s;
    public GameObject b2s;
    public GameObject b3s;
    public GameObject r1s;
    public GameObject r2s;
    public GameObject r3s;

    private void Start()
    {
        chosenBlueClone = blueCloneList[blueCloneIndex];
        chosenRedClone = redCloneList[redCloneIndex];
        chosenBlueSpawn = blueSpawnList[blueSpawnIndex].position;
        chosenRedSpawn = redSpawnList[redSpawnIndex].position;

        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        //set text
        SetText();

        //set growth 
        blueStock += blueGrowthRate * Time.deltaTime;
        redStock += redGrowthRate * Time.deltaTime;

        //choosing the clone and spawn point
        //cycle choose the blue clone to spawn
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(blueCloneIndex > 0)
            {
                blueCloneIndex--;
                Debug.Log("Blue clone index decreased by 1");
                Debug.Log("Blue clone index = " + blueCloneIndex.ToString());
                Floatymans();
            }
            chosenBlueClone = blueCloneList[blueCloneIndex];
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (blueCloneIndex < blueCloneList.Count - 1)
            {
                blueCloneIndex++;
                Debug.Log("Blue clone index increased by 1");
                Debug.Log("Blue clone index = " + blueCloneIndex.ToString());
                Floatymans();
            }
            chosenBlueClone = blueCloneList[blueCloneIndex];
        }
        //cycle choose the red clone to spawn
        else if (Input.GetKeyDown(KeyCode.Comma))
        {
            if (redCloneIndex > 0)
            {
                redCloneIndex--;
                Debug.Log("Red clone index decreased by 1");
                Debug.Log("Red clone index = " + redCloneIndex.ToString());
                Floatymans();
            }
            chosenRedClone = redCloneList[redCloneIndex];
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            if (redCloneIndex < redCloneList.Count - 1)
            {
                redCloneIndex++;
                Debug.Log("Red clone index increased by 1");
                Debug.Log("Red clone index = " + redCloneIndex.ToString());
                Floatymans();
            }
            chosenRedClone = redCloneList[redCloneIndex];
        }
        //cycle choose the blue spawn point
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (blueSpawnIndex > 0)
            {
                blueSpawnIndex--;
                Debug.Log("Blue spawn index decreased by 1");
                Debug.Log("Blue spawn index = " + blueSpawnIndex.ToString());
            }
            chosenBlueSpawn = blueSpawnList[blueSpawnIndex].position;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (blueSpawnIndex < blueSpawnList.Count - 1)
            {
                blueSpawnIndex++;
                Debug.Log("Blue spawn index increased by 1");
                Debug.Log("Blue spawn index = " + blueSpawnIndex.ToString());
            }
            chosenBlueSpawn = blueSpawnList[blueSpawnIndex].position;
        }
        //cycle choose the red spawn point
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (redSpawnIndex > 0)
            {
                redSpawnIndex--;
                Debug.Log("Red spawn index decreased by 1");
                Debug.Log("Red spawn index = " + redSpawnIndex.ToString());
            }
            chosenRedSpawn = redSpawnList[redSpawnIndex].position;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (redSpawnIndex < redSpawnList.Count - 1)
            {
                redSpawnIndex++;
                Debug.Log("Red spawn index increased by 1");
                Debug.Log("Red spawn index = " + redSpawnIndex.ToString());
            }
            chosenRedSpawn = redSpawnList[redSpawnIndex].position;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && blueStock >= 20 && blueHasUpgraded == false)
        {
            blueGrowthRate *= 1.5f;
            blueHasUpgraded = true;
            blueStock -= 20;
        }
        else if (Input.GetKeyDown(KeyCode.P) && redStock >= 20 && redHasUpgraded == false)
        {
            redGrowthRate *= 1.5f;
            redHasUpgraded = true;
            redStock -= 20;
        }

        //get the input to spawn the clone

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (blueStock >= 0)
            {
                SpawnBlueClone();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (redStock >= 0)
            {
                SpawnRedClone();
            }
        }
    }

    void Floatymans()
    {
        if (blueCloneIndex == 0)
        {
            //normalass
            bnormalass.SetActive(true);
            bspeedyboi.SetActive(false);
            bGOOSE.SetActive(false);
        }

        if (blueCloneIndex == 1)
        {
            //bigboi
            bnormalass.SetActive(false);
            bspeedyboi.SetActive(false);
            bGOOSE.SetActive(true);
        }

        if (blueCloneIndex == 2)
        {
            //speedyman
            bnormalass.SetActive(false);
            bspeedyboi.SetActive(true);
            bGOOSE.SetActive(false);
        }

        if (redCloneIndex == 0)
        {
            //normalass
            rnormalass.SetActive(true);
            rspeedyboi.SetActive(false);
            rGOOSE.SetActive(false);
        }

        if (redCloneIndex == 1)
        {
            //bigboi
            rnormalass.SetActive(false);
            rspeedyboi.SetActive(false);
            rGOOSE.SetActive(true);
        }

        if (redCloneIndex == 2)
        {
            //speedyman
            rnormalass.SetActive(false);
            rspeedyboi.SetActive(true);
            rGOOSE.SetActive(false);
        }
    }

    //spawn the chosen clone at chosen spawn point
    void SpawnBlueClone()
    {
        //if regular clone and at least one stock
        if (blueCloneIndex == 0 && blueStock >= regularCloneCost)
        {
            blueStock -= regularCloneCost;
            Instantiate(chosenBlueClone, chosenBlueSpawn, Quaternion.identity);
            Debug.Log("You spawned a regular blue clone!");
        }
        //or if heavy clone and at least on stock
        else if (blueCloneIndex == 1 && blueStock >= heavyCloneCost)
        {
            blueStock -= heavyCloneCost;
            Instantiate(chosenBlueClone, chosenBlueSpawn, Quaternion.identity);
            Debug.Log("You spawned a heavy blue clone!");
        }
        else if (blueCloneIndex == 2 && blueStock >= speedCloneCost)
        {
            blueStock -= speedCloneCost;
            Instantiate(chosenBlueClone, chosenBlueSpawn, Quaternion.identity);
            Debug.Log("You spawned a speedy blue clone!");
        }
    }
    void SpawnRedClone()
    {
        //if regular clone and at least one stock
        if (redCloneIndex == 0 && redStock >= regularCloneCost)
        {
            redStock -= regularCloneCost;
            Instantiate(chosenRedClone, chosenRedSpawn, Quaternion.identity);
            Debug.Log("You spawned a regular red clone!");
        }
        //or if heavy clone and at least on stock
        else if (redCloneIndex == 1 && redStock >= heavyCloneCost)
        {
            redStock -= heavyCloneCost;
            Instantiate(chosenRedClone, chosenRedSpawn, Quaternion.identity);
            Debug.Log("You spawned a heavy red clone!");
        }
        else if (redCloneIndex == 2 && redStock >= speedCloneCost)
        {
            redStock -= speedCloneCost;
            Instantiate(chosenRedClone, chosenRedSpawn, Quaternion.identity);
            Debug.Log("You spawned a speedy red clone!");
        }
    }

    //sets the text objects
    void SetText()
    {
        blueStockText.text = "Blue stock = " + blueStock.ToString("F1");
        redStockText.text = "Red stock = " + redStock.ToString("F1");
    }
}
