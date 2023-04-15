using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLiveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Power Up: 1-UP");
            collision.GetComponent<Lives>()._continues++;
            Destroy(gameObject);
        }
    }
}
