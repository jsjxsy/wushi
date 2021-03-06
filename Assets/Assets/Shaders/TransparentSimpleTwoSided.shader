Shader "MADFINGER/Transparent/Lighting Off Two Sided" { 
   Properties { 
      _Color ("Color", Color) = (1,1,1,1) 
      _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {} 
   } 
   Category { 
      ZWrite Off 
      Alphatest Greater 0 
      Tags {Queue=Transparent} 
      Blend SrcAlpha OneMinusSrcAlpha 
       
      SubShader { 
         Pass { 
            Lighting Off 
            Cull Off
            SetTexture [_MainTex] 
            { 
               constantColor [_Color] 
               Combine texture * constant, texture * constant 
            } 
         } 
      } 
   } 
} 