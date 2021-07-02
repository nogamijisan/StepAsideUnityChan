using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    GameObject myUnityChan;

    private int startPos = 80;
    private int goalPos = 360;

    private float posRange = 3.4f;

    private int instSpan = 40;

    private int prePoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        //for(int i = startPos; i<goalPos;i+=15){ CreateItem(i); }
        myUnityChan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //START POS + 15* = CREATE POINT
        //UnityC.z + instSpan = Create Cursol
        // if(cursol = point) create
        // then (UnityC.z + instSpan - startPos)%15=0

        int point = Mathf.FloorToInt(myUnityChan.GetComponent<Transform>().position.z + instSpan);
        if (((point - prePoint) >= 15) && point <= goalPos)
        {
            this.prePoint = point;
            CreateItem(point);
        }

        // ich meinst "MARUME!"
        // 

    }



    // Item Generate function
    void CreateItem(int i)
    {
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
            }
        }
        else
        {
            for (int j = -1; j <= 1; j++)
            {
                int item = Random.Range(1, 11);
                int offsetZ = Random.Range(-5, 6);
                //60%Coin Generate 20%Car Generate
                if (1 <= item && item <= 6)
                {
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);

                }
            }
        }
    }
}
