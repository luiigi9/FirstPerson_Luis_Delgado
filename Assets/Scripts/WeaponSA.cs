using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSA : MonoBehaviour
{
    [SerializeField] private WeaponSO data1;
    [SerializeField] private ParticleSystem ps;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ps.Play();
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, data1.distanceAttack))
            {
                if(hitInfo.transform.CompareTag("EnemyPart"))
                //hitInfo.transform;
                hitInfo.transform.GetComponent<EnemyPart>().DamageRecieved(data1.damageAttack);
            }
        }
    }
}
