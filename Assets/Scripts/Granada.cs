using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Granada : MonoBehaviour
{

    //HACE FALTA PONER A CADA PARTE DEL ENEMIGO EL LAYER DAMAGABLE (EL LAYER QUE PIDE AQUI)

    private Rigidbody rb;
    [SerializeField] private LayerMask damagable;
    [SerializeField] private int impulseV;
    [SerializeField] private GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward.normalized * impulseV, ForceMode.Impulse);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, 5, damagable);
        if (colliderArray.Length > 0)
        {
            foreach (Collider collider in colliderArray)
            {
                collider.GetComponent<EnemyPart>().Explote();
                collider.GetComponent<Rigidbody>().AddExplosionForce(50, transform.position, 5, 4, ForceMode.Impulse); //% es el radio de explosion y 4 es el radius modifier (cuanto levanta la explsion al afectado)
                collider.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
