using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMove : MonoBehaviour
{

    public GameObject world;
    

    public void WorldMoving(Slider slider)
    {
        world.transform.position = new Vector3(0,0, slider.value * -1);
    }
}
