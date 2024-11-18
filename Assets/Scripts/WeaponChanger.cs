using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] GameObject[] guns;
    private int indice = 0;
    private float scrollwheel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardChange();
        MouseChange();
    }
    private void MouseChange()
    {
        scrollwheel = Input.GetAxis("Mouse ScrollWheel");
        if(scrollwheel > 0)
        {
            ChangeGun(indice + 1);
        }
        else if (scrollwheel < 0)
        {
            ChangeGun(indice - 1);
        }
    }

    private void KeyboardChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeGun(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(2);
        }
    }

    private void ChangeGun(int i)
    {
        
        if (i >= guns.Length && i < guns.Length)
        {
            indice = i;
            guns[indice].SetActive(true);
            guns[indice].SetActive(false);
        }
        
    }
}
