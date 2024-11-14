using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private float gravityScale;
    private Vector3 movementY;
    CharacterController cc;
    private Camera cam;
    [SerializeField] Transform feet;
    [SerializeField] private float rayCast;
    [SerializeField] private LayerMask wtIsFloor;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float life;

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
        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0); //Linea para que el cuerpo rote con la camara
        if (movimento.sqrMagnitude > 0)
        {
            float angleRotazzione = Mathf.Atan2(movimento.x, movimento.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, angleRotazzione, 0);
            Vector3 movement = Quaternion.Euler(0, angleRotazzione, 0) * Vector3.forward;
            cc.Move(movement * speedMovement * Time.deltaTime);
        }
        Gravity();
        FloorDetector();
        
        
    }
    private void Gravity()
    {
        movementY.y += gravityScale * Time.deltaTime;
        cc.Move(movementY * Time.deltaTime);
    }
    private void FloorDetector()
    {
        Collider[] colliderArray = Physics.OverlapSphere(feet.position, rayCast, wtIsFloor);
        if (colliderArray.Length > 0)
        {
            movementY.y = 0;
            Jump();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("EnemyPart"))
        {
            Rigidbody rbE = hit.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = hit.transform.position - transform.position;
            rbE.AddForce(forceDirection.normalized * 50, ForceMode.Impulse);
        }
    }
    public void Damage(float damageR)
    {
        life -= damageR;
        if (life <= 0)
        {
            Destroy(gameObject);
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(feet.position, rayCast);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movementY.y = Mathf.Sqrt(-2 * gravityScale * jumpHeight);
        }

    }
}
