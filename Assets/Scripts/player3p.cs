using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class player3p : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    CharacterController cc;
    private Camera cam;
    [SerializeField] private float smooth;
    private float velocidadRotasao;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

    }

    private void Movimiento()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 movimento = new Vector2(h, v).normalized;

        if (movimento.sqrMagnitude > 0)
        {
            anim.SetBool("Walk", true);
            float angleRotazzione = Mathf.Atan2(movimento.x, movimento.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleRotazzione, ref velocidadRotasao, 0.3f);
            transform.eulerAngles = new Vector3(0, smoothAngle, 0);
            Vector3 movement = Quaternion.Euler(0, angleRotazzione, 0) * Vector3.forward;
            cc.Move(movement * speedMovement * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }
}
