Shader "Custom/Portal"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"


            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _InactiveColour;
            int displayMask; // set to 1 to display texture, otherwise will draw test colour
            
           
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
{
    // Calculate screen aspect ratio (from _ScreenParams)
    float screenAspect = _ScreenParams.x / _ScreenParams.y;

    // Normalize the screen coordinates (UV space)
    float2 uv = i.screenPos.xy / i.screenPos.w;

    // Scale the UV.x to stretch the texture based on screen aspect ratio
    uv.x = (uv.x - 0.5) * screenAspect + 0.5;

    // Now apply the stretch factor only to the X axis, keeping the Y coordinate as-is
    // Centering the texture: we already subtracted 0.5 before stretching, so no further adjustments needed for centering
    fixed4 portalCol = tex2D(_MainTex, uv);

    return portalCol;
}
            ENDCG
        }
    }
    Fallback "Standard" // for shadows
}