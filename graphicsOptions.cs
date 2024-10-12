using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine;

public class graphicsOptions : MonoBehaviour
{
    [Header("Graphics menu options (make vsync on, etc)")] //Just for text
    public TextMeshProUGUI vsyncOn;
    public TextMeshProUGUI vsyncOff;
    public TextMeshProUGUI softShadowOn;
    public TextMeshProUGUI softShadowOff;

    [Header("Post process menu options")] //Text and volume to change Post Process
    public TextMeshProUGUI vignetteOn;
    public TextMeshProUGUI vignetteOff;
    public TextMeshProUGUI filmGrainOn;
    public TextMeshProUGUI filmGrainOff;
    public TextMeshProUGUI bloomOn;
    public TextMeshProUGUI bloomOff;
    public Volume globalVolume;

    #region Vsync and SoftShadows
    public void TurnVsyncOn()
    {
        QualitySettings.vSyncCount = 1; //Enable Vsync
        vsyncOff.color = new Color32(45, 45, 45, 200); //This just changes the text color to indicate that VSync has been turned off
        vsyncOn.color = new Color32(255, 255, 255, 255); //This just changes the text color to indicate that VSync has been turned on
    }
    public void TurnVsyncOff()
    {
        QualitySettings.vSyncCount = 0; //Disable Vsync
        vsyncOn.color = new Color32(45, 45, 45, 200); 
        vsyncOff.color = new Color32(255, 255, 255, 255);
    }

    public void SoftShadowOn()
    {
        Light[] allLights = Resources.FindObjectsOfTypeAll<Light>(); //Find all light objects

        foreach (Light i in allLights) //Iterate through all lights in the scene
        {
            if (i != null && i.gameObject.CompareTag("light"))
            {
                i.shadows = LightShadows.Soft; //Enable soft shadows
            }
        }
        softShadowOff.color = new Color32(45, 45, 45, 200); //Same color change logic as VSync.
        softShadowOn.color = new Color32(255, 255, 255, 255); 
    }
    public void SoftShadowOff()
    {
        Light[] allLights = Resources.FindObjectsOfTypeAll<Light>(); //Find the light type object

        foreach (Light i in allLights) //Iterate through all lights in the scene
        {
            if (i != null && i.gameObject.CompareTag("light"))
            {
                i.shadows = LightShadows.Hard; //Disable soft shadows
            }
        }
        softShadowOn.color = new Color32(45, 45, 45, 200); //Same color change logic as VSync.
        softShadowOff.color = new Color32(255, 255, 255, 255); 
    }
    #endregion

    #region PostFX
    public void VignetteOn()
    {
        if (globalVolume.profile.TryGet(out Vignette vignette)) //Retrieve the Vignette component from the post-processing profile
        {
            vignette.active = true; //Enables vignette effect
        }
        vignetteOff.color = new Color32(45, 45, 45, 200); //Change the text color to indicate the vignette effect is off
        vignetteOn.color = new Color32(255, 255, 255, 255); //Change the text color to indicate the vignette effect is on
    }
    public void VignetteOff()
    {
        if (globalVolume.profile.TryGet(out Vignette vignette)) //Retrieve the Vignette component from the post-processing profile
        {
            vignette.active = false; //Disable vignette effect
        }
        vignetteOn.color = new Color32(45, 45, 45, 200); //Change the text color to indicate the vignette effect is on
        vignetteOff.color = new Color32(255, 255, 255, 255); //Change the text color to indicate the vignette effect is off
    }
    public void FilmGrainOn()
    {
        if (globalVolume.profile.TryGet(out FilmGrain filmGrain)) //Retrieve the Film Grain component from the post-processing profile
        {
            filmGrain.active = true; //Enables film grain
        }
        filmGrainOff.color = new Color32(45, 45, 45, 200); //Same color change logic as vignette effect.
        filmGrainOn.color = new Color32(255, 255, 255, 255);
    }
    public void FilmGrainOff()
    {
        if (globalVolume.profile.TryGet(out FilmGrain filmGrain)) //Retrieve the Film Grain component from the post-processing profile
        {
            filmGrain.active = false; //Disables film grain
        }
        filmGrainOn.color = new Color32(45, 45, 45, 200); //Same color change logic as vignette effect.
        filmGrainOff.color = new Color32(255, 255, 255, 255);
    }
    public void BloomOn()
    {
        if (globalVolume.profile.TryGet(out Bloom bloom)) //Retrieve the Bloom component from the post-processing profile
        {
            bloom.active = true; //Enables bloom effect
        }
        bloomOff.color = new Color32(45, 45, 45, 200); //Same color change logic as vignette effect.
        bloomOn.color = new Color32(255, 255, 255, 255);
    }
    public void BloomOff()
    {
        if (globalVolume.profile.TryGet(out Bloom bloom))
        {
            bloom.active = false; //Disables bloom effect
        }
        bloomOn.color = new Color32(45, 45, 45, 200); //Same color change logic as vignette effect.
        bloomOff.color = new Color32(255, 255, 255, 255);
    }
    #endregion
}
