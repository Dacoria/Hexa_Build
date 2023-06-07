using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FogOnHex : BaseEventCallback
{
    public ParticleSystem ParticleSystem; // wordt geset door ander script bij het aanmaken van dit script
    [ComponentInject] private Hex hex;


    private void Start()
    {
        this.SetFog(hex.InitFogIsActive);
    }

    public void SetFog(bool isFogActive)
    {
        ParticleSystem.gameObject.SetActive(isFogActive);
    }

    public bool FogIsActive() => ParticleSystem.gameObject.activeSelf;
}