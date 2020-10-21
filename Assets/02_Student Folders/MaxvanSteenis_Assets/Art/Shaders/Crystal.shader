Shader "Custom/Crystal"
{
    Properties
    {
        _colour ("Crystal colour", Color) = (1,1,1,1)
        _brightness ("Brightness", Range(0,5)) = 1
        _cube ("Crystal cube", CUBE) = "white" {}
        _cubeIntensity ("Cube intensity", Range(0,5)) = 0.65
    }

    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        float4 _colour;
        float _brightness;
        samplerCUBE _cube;
        float _cubeIntensity;

        struct Input
        {
            float3 viewDir;
            float3 worldRefl;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            half dotp = dot(IN.viewDir, o.Normal);
            o.Emission = (texCUBE(_cube, WorldReflectionVector(IN, o.Normal)) * _cubeIntensity
                + dotp * _colour).rgb * _brightness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
