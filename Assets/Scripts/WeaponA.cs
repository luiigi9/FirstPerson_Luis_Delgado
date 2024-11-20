using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponA : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private WeaponSO data2;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        data2.cadenceAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= data2.cadenceAttack)
        {
            ps.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, data2.distanceAttack))
            {
                if (hitInfo.transform.CompareTag("EnemyPart"))
                    hitInfo.transform.GetComponent<EnemyPart>().DamageRecieved(data2.damageAttack);
            }
            timer = 0;
        }
    }
}
