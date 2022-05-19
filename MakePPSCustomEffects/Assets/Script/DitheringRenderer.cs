using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public sealed class DitheringRenderer : PostProcessEffectRenderer<Dithering>
{
    public override void Init()
    {
        base.Init();
    }

    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/PPS_Dither"));

        if (settings.bayerArrayTex.value != null) sheet.properties.SetTexture("_BayerArrayTex", settings.bayerArrayTex);

        if (settings.monochromeColor != null)
        {
            float monochromeToggle = settings.monochromeColor == false ? 0 : 1;
            sheet.properties.SetFloat("_MonochromeToggle", monochromeToggle);
        }

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }

    public override void Release()
    {
        base.Release();
    }
}
