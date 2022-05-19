Shader "Custom/PPS_Dither"
{
    
    SubShader
    {
        Cull Off
        ZWrite Off
        ZTest Always

        Pass
        {
            HLSLPROGRAM
            #pragma vertex VertDefault
            #pragma fragment Frag
            
            #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

            TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
            TEXTURE2D_SAMPLER2D(_BayerArrayTex, sampler_BayerArrayTex);

            float _MonochromeToggle;

            float4 Frag(VaryingsDefault i) : SV_Target
            {
                float4 texCol = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
                float V = max(texCol.r, max(texCol.g, texCol.b));

                float2 bayerArrayUV = i.texcoord * _ScreenParams.xy/4.;
                float threshold =  SAMPLE_TEXTURE2D(_BayerArrayTex, sampler_BayerArrayTex, bayerArrayUV).r;
                float3 binary = ceil(V - threshold);

                float3 col = saturate(texCol.rgb + _MonochromeToggle) * binary;
                float4 lastCol = float4(col,1.);
                
                return lastCol;
            }
            ENDHLSL
        }
    }
}
