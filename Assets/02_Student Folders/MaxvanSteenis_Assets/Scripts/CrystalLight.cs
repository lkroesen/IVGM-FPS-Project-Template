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
    
    [Header("Light data")]
    [Tooltip("Crystal off brightness")]
    [SerializeField] private float _offBrightness= 0.07f;

    [Tooltip("Crystal shine brightness")] [SerializeField]
    private float _onBrightness = 1f;
    [Tooltip("Crystal shine time")]
    [SerializeField] private float _waitTime = 5;

    private Light _light;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Awake()
    {
        _light = GetComponent<Light>();
        _renderer = GetComponent<Renderer>();
        
        if (_alwaysOn)
        {
            LightOn();
        }
        
        else
        {
            _light.enabled = false;
            _renderer.material.SetFloat("_brightness", _offBrightness);
        }
    }

    // The light is turned on and the material's brightness is turned up to accentuate the light coming from the crystal
    public void LightOn()
    {
        _light.enabled = true;
        _renderer.material.SetFloat("_brightness", _onBrightness);
        if (!_alwaysOn && !_oneWayToggle)
        {
            StartCoroutine(LightOff());
        }
    }
    
    // After a certain wait time, the light is turned off again.
    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(_waitTime);
        _light.enabled = false;
        _renderer.material.SetFloat("_brightness", _offBrightness);
    }
}
