using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines_ : MonoBehaviour
{
    private bool controlRoutine = false;
    // Start is called before the first frame update
    void Start()
    {
        //Coroutine nombre = StartCoroutine(TrafficLight()); Para tener localizados las coroutinas que abres y si luego quieres cerrar -> StopCoroutine(nombre);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && controlRoutine == false) {
            StartCoroutine(TrafficLight());
            controlRoutine = true;
        } 
    }
    IEnumerator TrafficLight()
    {
        while (1 == 1)
        {
            //Instruccion1
            yield return new WaitForSeconds(2);
            //Instruccion2
        }

    }
}
