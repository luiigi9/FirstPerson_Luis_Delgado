using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGranade : MonoBehaviour
{
    [SerializeField] private GameObject granadePrefab;
    [SerializeField] private Transform point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(granadePrefab, point.position, point.rotation);
        }
        
    }
}
