using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEffect : MonoBehaviour
{
    private Volume effect;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        effect = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (effect.profile.TryGet(out LensDistortion distorsion))
        {
            FloatParameter fpx = new FloatParameter (1 + Mathf.Cos(speed * Time.time) / 2);
            FloatParameter fpy = new FloatParameter(1 + Mathf.Sin(speed * Time.time) / 2);
            distorsion.xMultiplier.SetValue(fpx);
            distorsion.yMultiplier.SetValue(fpy);
        }
    }
}
