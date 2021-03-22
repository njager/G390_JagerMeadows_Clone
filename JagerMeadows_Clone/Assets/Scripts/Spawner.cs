using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public variables
    public float blueStock;
    public float redStock;
    public float growthRate;

    //private variables
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

    private void Start()
    {
        chosenBlueClone = blueCloneList[blueCloneIndex];
        chosenRedClone = redCloneList[redCloneIndex];
        chosenBlueSpawn = blueSpawnList[blueSpawnIndex].position;
        chosenRedSpawn = redSpawnList[redSpawnIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        //set growth 
        blueStock += growthRate * Time.deltaTime;
        redStock += growthRate * Time.deltaTime;

        //choosing the clone and spawn point
        //cycle choose the blue clone to spawn
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(blueCloneIndex > 0)
            {
                blueCloneIndex--;
                Debug.Log("Blue clone index decreased by 1");
                Debug.Log("Blue clone index = " + blueCloneIndex.ToString());
            }
            chosenBlueClone = blueCloneList[blueCloneIndex];
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (blueCloneIndex < blueCloneList.Count)
            {
                blueCloneIndex++;
                Debug.Log("Blue clone index increased by 1");
                Debug.Log("Blue clone index = " + blueCloneIndex.ToString());
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
            }
            chosenRedClone = redCloneList[redCloneIndex];
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            if (redCloneIndex < redCloneList.Count)
            {
                redCloneIndex++;
                Debug.Log("Red clone index increased by 1");
                Debug.Log("Red clone index = " + redCloneIndex.ToString());
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
            if (blueSpawnIndex < blueSpawnList.Count)
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
            if (redSpawnIndex < redSpawnList.Count)
            {
                redSpawnIndex++;
                Debug.Log("Red spawn index increased by 1");
                Debug.Log("Red spawn index = " + redSpawnIndex.ToString());
            }
            chosenRedSpawn = redSpawnList[redSpawnIndex].position;
        }


        //get the input to spawn the clone
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpawnBlueClone();
        }
        else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            SpawnRedClone();
        }

    }

    void SpawnBlueClone()
    {
        Instantiate(chosenBlueClone, chosenBlueSpawn, Quaternion.identity);
    }

    void SpawnRedClone()
    {
        Instantiate(chosenRedClone, chosenRedSpawn, Quaternion.identity);
    }
}
