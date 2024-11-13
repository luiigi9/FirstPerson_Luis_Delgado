using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    private Animator anmtrBox;
    //SCRIPT IDENTIFICADOR DE UNA CAJA DE MUNICION


    /*Animar la apertura de la caja.
        1. Abrir animator y crear una animacion nueva
        2. Una vez creada, empezar a formarla con los keyframes (para que la tapa gire correctamente, hay que cambiar la opcion de "center" a "pivot" (esquina superior izquierda)
        3. Despues de crear la animacion, vamos a la pestaña de su animator y le quitamos el loop
        4. En el animator, le das click derecho al fondo y creas un State vacio y despues le das a click derecho a ese estado y a "Set state default"
        5. Crea una transicion del evento vacio a la animacion de abrir la caja creando un evento(parameter) de Trigger.
        6. La configuracion de la animación será "Has exit time" quitado y "transition duration" en 0*/
    private void Start()
    {
        anmtrBox = GetComponent<Animator>();
    }

    public void OpenBox()
    {
        //anmtrBox.SetTrigger("Open");
    }
}
