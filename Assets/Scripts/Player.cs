using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 movimento = new Vector2(h, v).normalized;
        if (movimento.magnitude > 0)
        {
            float angleRotazzione = Mathf.Atan2(movimento.x, movimento.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, angleRotazzione, 0);
            Vector3 movement = Quaternion.Euler(0, angleRotazzione, 0) * Vector3.forward;
            cc.Move(movement * speedMovement * Time.deltaTime);
        }
        
        
    }
}
