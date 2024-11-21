using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterVFX : MonoBehaviour
{
    private Volume vlm;
    // Start is called before the first frame update
    void Start()
    {
        vlm = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vlm.profile.TryGet(out LensDistortion distortion))
        {
            //distortion.xMultiplier
        }
    }
}
