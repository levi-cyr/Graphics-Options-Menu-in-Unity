using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
public class graphicsOptionsDropdown : MonoBehaviour
{
    public void SetTextureQualityMode(int textureQuality)
    {
        switch (textureQuality)
        {
            case 0: //Set texture quality to low
                QualitySettings.globalTextureMipmapLimit = 2; //Limits texture mipmap to low quality
                break;
            case 1: //Set texture quality to medium
                QualitySettings.globalTextureMipmapLimit = 1; //Limits texture mipmap to low quality
                break;
            case 2: //Set texture quality to high
                QualitySettings.globalTextureMipmapLimit = 0; //Limits texture mipmap to highest quality
                break;
        }
    }

    public void SetShadowQualityMode(int shadowQuality)
    {
        //Get the current render pipeline asset and cast it to UniversalRenderPipelineAsset
        UniversalRenderPipelineAsset urp = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
        switch (shadowQuality)
        {
            case 0: //Set shadow quality to low
                urp.shadowDistance = 8; //Set shadow render distance to low quality 
                break;
            case 1: //Set shadow quality to medium
                urp.shadowDistance = 15; //Set shadow render distance to medium quality 
                break;
            case 2: //Set shadow quality to high
                urp.shadowDistance = 30; //Set shadow render distance to high quality 
                break;
        }
    }
}
