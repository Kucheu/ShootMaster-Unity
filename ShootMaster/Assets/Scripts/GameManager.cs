using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Timer timer;
    public GameObject Targets;
    public GameObject targetPrefab;
    GameObject[,] targetsPlaces = new GameObject[5, 5] { { null, null, null, null, null }, { null, null, null, null, null }, { null, null, null, null, null }, { null, null, null, null, null }, { null, null, null, null, null } };
    public float acturalPoints = 0f;
    public float MaxPoints = 0f;
    public float combo = 0f;

    public bool activeTimer = false;


    // Start is called before the first frame update
    void Start()
    {
        //Load Best Points

        Points data = SaveSystem.LoadBestPoints();
        Debug.Log(data);
        if (data != null)
        {
            MaxPoints = data.MaxPoints;
        }



        //Create targets
        for (int i = 0; i <= 4; i++)
        {
            for (int j = 0; j <= 4; j++)
            {
                GameObject target = Instantiate(targetPrefab); ;
                target.transform.SetParent(Targets.transform);
                target.transform.position = Targets.transform.position - new Vector3(-(i * 1.5f), -(j * 1.5f), (0));


                targetsPlaces[i, j] = target;
                target.SetActive(false);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimer && !timer.isCountingDown)
        {
            TargetDespawn();
            activeTimer = false;
            if (acturalPoints > MaxPoints)
            {
                SaveSystem.SaveBestPoints(acturalPoints);
                MaxPoints = acturalPoints;
            }

        }
    }

    public void GetPoint()
    {
        if (activeTimer && timer.isCountingDown)
        {
            combo += 1;
            acturalPoints += 10 * combo;
            TargetSpawn();
        }
    }
    public void MissShot()
    {
        if (activeTimer && timer.isCountingDown)
        {
            combo = 0f;
        }
    }
    public void StartRound()
    {
        
        //Timer

        if (timer.isCountingDown)
        {
            TargetDespawn();
            activeTimer = false;
            timer.Stop();
        }
        else
        {
            activeTimer = true;
            acturalPoints = 0f;
            combo = 0f;
            timer.Begin();

            TargetSpawn();
            TargetSpawn();
            TargetSpawn();
        }
        
    }

    private void TargetSpawn()
    {
        if(activeTimer)
        {
            int i = Random.Range(0, 5);
            int j = Random.Range(0, 5);

            if (targetsPlaces[i, j].activeSelf)
            {
                TargetSpawn();
            }
            else
            {
                targetsPlaces[i, j].SetActive(true);
            }
        }
        
    }

    private void TargetDespawn()
    {
        for(int i = 0; i < 5; i ++)
        {
            for(int j = 0; j < 5; j++)
            {
                targetsPlaces[i, j].SetActive(false);
            }
        }
    }
}
