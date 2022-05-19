using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System;

[Serializable]
[PostProcess(typeof(DitheringRenderer), PostProcessEvent.AfterStack, "Custom/PPS_Dither", true)]
public sealed class Dithering : PostProcessEffectSettings
{
    public TextureParameter bayerArrayTex = new TextureParameter { value = null };

    public BoolParameter monochromeColor = new BoolParameter { value = false };
    
    //public override bool IsEnabledAndSupported(PostProcessRenderContext context)
    //{
    //    return base.IsEnabledAndSupported(context) || bayerArrayTex != null;
    //}
}
