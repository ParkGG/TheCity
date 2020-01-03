using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    [Header("DefaultSetting")]
    public Vector3 terrainSize;



    private Terrain terrain;
    private Vector3 newTerrainSize;


    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrain.terrainData.size = Vector3.zero;

        newTerrainSize.x += terrainSize.z * AnchorTransform.Instance.AnchorScale;
        newTerrainSize.z += terrainSize.x * AnchorTransform.Instance.AnchorScale;
        newTerrainSize.y = terrainSize.z * 2;

        terrain.terrainData.size = newTerrainSize;

        //gameObject.transform.localPosition = new Vector3((newTerrainSize.x / 2.0f) * -1, 0, (newTerrainSize.z / 2.0f) * -1);
    }


}
