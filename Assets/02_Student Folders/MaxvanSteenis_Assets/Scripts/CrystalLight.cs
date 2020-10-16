using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLight : MonoBehaviour
{
    [Header("Ways to keep the light on.")]
    [Tooltip("Should the crystal always be on without it having to be shot first?")]
    [SerializeField] private bool _alwaysOn = false;
    [Tooltip("Should the crystal stay on after being shot?")]
    [SerializeField] private bool _oneWayToggle = false;
    [SerializeField] private bool _laserToggle = true;
    
    [Header("Light data")]
    [Tooltip("Crystal shader emission brightness when off")]
    [SerializeField] private float _shaderOffBrightness= 0.07f;
    [Tooltip("Crystal shader emission brightness when on")]
    [SerializeField] private float _shaderOnBrightness = 1f;

    [SerializeField] private float _crystalLightRange = 15f;
    [Tooltip("Crystal shine time")]
    [SerializeField] private float _waitTime = 5;

    private bool _lightIsOn = false;
    private Light _light;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Awake()
    {
        _light = GetComponent<Light>();
        _renderer = GetComponent<Renderer>();
        _light.range = _crystalLightRange;
        
        if (_alwaysOn)
        {
            LightOn();
        }
        
        else
        {
            _light.enabled = false;
            _renderer.material.SetFloat("_brightness", _shaderOffBrightness);
        }
    }

    // The light is turned on and the material's brightness is turned up to accentuate the light coming from the crystal
    public void LightOn()
    {
        _light.enabled = true;
        _renderer.material.SetFloat("_brightness", _shaderOnBrightness);
        if (!_alwaysOn && !_oneWayToggle && !_lightIsOn)
        {
            StartCoroutine(LightOff());
        }
        _lightIsOn = true;
    }
    
    // After a certain wait time, the light is turned off again.
    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(_waitTime);
        _light.enabled = false;
        _renderer.material.SetFloat("_brightness", _shaderOffBrightness);
        _lightIsOn = false;
    }

    public bool IsToggleLaser()
    {
        return _laserToggle;
    }
}
