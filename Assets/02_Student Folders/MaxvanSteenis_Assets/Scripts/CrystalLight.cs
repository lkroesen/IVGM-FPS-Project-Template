using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLight : MonoBehaviour
{
    [Tooltip("Should the crystal always be on without it having to be shot first?")]
    [SerializeField] private bool _alwaysOn = false;
    [Tooltip("Should the crystal stay on after being shot?")]
    [SerializeField] private bool _oneWayToggle = false;
    [Tooltip("How long will it take for the crystal's light to turn off again?")]
    [SerializeField] private float _waitTime = 5;

    private Light _light;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
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
            _renderer.material.SetFloat("_brightness", 0.06f);
        }
    }

    // The light is turned on and the material's brightness is turned up to accentuate the light coming from the crystal
    public void LightOn()
    {
        _light.enabled = true;
        _renderer.material.SetFloat("_brightness", 1);
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
        _renderer.material.SetFloat("_brightness", 0.06f);
    }
}
