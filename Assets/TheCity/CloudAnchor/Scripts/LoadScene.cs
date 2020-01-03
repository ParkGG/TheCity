using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleARCore.Examples.CloudAnchors;
using GoogleARCore;

public class LoadScene : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        
        if(scene == "TheCity_AugmentedImage")
        {
        
            Object[] test = GameObject.FindObjectsOfType(typeof(Anchor));

            for(int i = 0; i<test.Length; ++i)
            {
                Destroy(test[i]);
            }
        }

        SceneManager.LoadScene(scene);
    }
}
