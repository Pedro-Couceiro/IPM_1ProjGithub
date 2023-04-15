using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeDestroy : MonoBehaviour
{
    private float age;

    [SerializeField] private float _projecLife;

    void Start()
    {
        age = 0;
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;

        if(age > _projecLife)
        {
            Destroy(gameObject);
        }
    }
}
