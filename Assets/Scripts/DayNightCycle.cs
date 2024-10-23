using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float _time;
    public float _fullDayLength;
    public float _startTime = 0.4f;
    public Vector3 _noon; // Vector 90 0 0 : Á¤¿À

    private float _timeRate;

    [Header("Sun")]
    public Light _sun;
    public Gradient _sunColor;
    public AnimationCurve _sunIntensity;

    [Header("Moon")]
    public Light _moon;
    public Gradient _moonColor;
    public AnimationCurve _moonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve _lightingIntensityMultiplier;
    public AnimationCurve _reflectionIntensityMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        _timeRate = 1.0f / _fullDayLength;
        _time = _startTime;
    }

    // Update is called once per frame
    void Update()
    {
        _time = (_time + _timeRate * Time.deltaTime) % 1.0f;

        UpdateLighting(_sun,_sunColor,_sunIntensity);
        UpdateLighting(_moon, _moonColor, _moonIntensity);

        RenderSettings.ambientIntensity = _lightingIntensityMultiplier.Evaluate(_time);
        RenderSettings.reflectionIntensity = _reflectionIntensityMultiplier.Evaluate(_time);
    }

    private void UpdateLighting(Light lightSource, Gradient gradient, AnimationCurve intensityCurve)
    {
        float intensity = intensityCurve.Evaluate(_time);

        lightSource.transform.eulerAngles = (_time - (lightSource == _sun ? 0.25f : 0.75f)) * _noon * 4f;
        lightSource.color = gradient.Evaluate(_time);
        lightSource.intensity = intensity;

        GameObject go = lightSource.gameObject;
        if(lightSource.intensity == 0 && go.activeInHierarchy)
        {
            go.SetActive(false);
        }
        else if(lightSource.intensity > 0 && !go.activeInHierarchy)
        {
            go.SetActive(true);
        }
    }
}
