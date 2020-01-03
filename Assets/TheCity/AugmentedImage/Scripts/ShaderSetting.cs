using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSetting : MonoBehaviour
{

    public Material[] materials;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < materials.Length; ++i)
            materials[i].shader = Shader.Find("Custom/Specular Stencil Filter");
    }

  
}
