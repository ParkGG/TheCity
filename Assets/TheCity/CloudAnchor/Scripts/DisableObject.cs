using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject city;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< city.transform.childCount; ++i)
        {
            if(city.transform.GetChild(i).childCount > 0)
            {
                for(int j = 0; j< city.transform.GetChild(i).childCount; ++j)
                {
                    city.transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
                }
            }
        }
    }

    
}
