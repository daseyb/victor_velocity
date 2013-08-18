Shader "Custom/uv_animation" 
{
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Offset ("Offset", Float) = 0.0
	}
	
	SubShader 
	{
		Tags { "Queue" = "Transparent" }
		Tags { "RenderType"="Transparent" }
		LOD 200
		
		Pass
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
		
			uniform sampler2D _MainTex;
			uniform float _Offset;
	
         	struct vertexInput {
            	float4 vertex : POSITION;
            	float4 texcoord : TEXCOORD0;
         	};
         	struct vertexOutput {
            	float4 pos : SV_POSITION;
            	float4 tex : TEXCOORD0;
         	};
 
	        vertexOutput vert (vertexInput input) 
	        {
	            vertexOutput output;
	            
	            output.tex = input.texcoord;
	            output.tex.y += _Offset;
	           
	            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
	           
	            return output;
	        }
	 
	        float4 frag(vertexOutput input) : COLOR
	        {
	            float4 textureColor = tex2D(_MainTex, float2(input.tex));  
	            return textureColor;
	        }

			ENDCG
		}
	} 
	FallBack "Unlit/Transparent"
}
