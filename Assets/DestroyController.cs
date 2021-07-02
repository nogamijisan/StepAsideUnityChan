using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{

    GameObject myCamera;

    // Start is called before the first frame update
    void Start()
    {
        this.myCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float myPozZ = this.GetComponent<Transform>().position.z;
        float cameraPozZ = myCamera.GetComponent<Transform>().position.z;
        if (myPozZ < cameraPozZ)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed!");
        }

    }
}
