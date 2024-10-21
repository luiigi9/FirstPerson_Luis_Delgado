using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    CharacterController cc;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 movimento = new Vector2(h, v).normalized;
        if (movimento.sqrMagnitude > 0)
        {
            float angleRotazzione = Mathf.Atan2(movimento.x, movimento.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, angleRotazzione, 0);
            Vector3 movement = Quaternion.Euler(0, angleRotazzione, 0) * Vector3.forward;
            cc.Move(movement * speedMovement * Time.deltaTime);
        }
        
        
    }
}
