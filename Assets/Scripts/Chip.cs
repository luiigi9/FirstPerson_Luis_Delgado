using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    [SerializeField] Vector3 rotacion, direccionR;
    [SerializeField] int velocidad;
    [SerializeField] float velocidadMov;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(direccionR * velocidadMov * Time.deltaTime);
        if (timer >= 1)
        {
            direccionR.z = direccionR.z * -1;
            timer = 0;
        }
        transform.Rotate(rotacion * velocidad * Time.deltaTime);

    }
}
