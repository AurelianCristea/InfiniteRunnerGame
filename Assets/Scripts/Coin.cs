using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{


    private void Start()
    {
        
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
    }
}
