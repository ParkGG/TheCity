using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AnchorTransform : NetworkBehaviour
{
    private static AnchorTransform _instance;
    public static AnchorTransform Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType(typeof(AnchorTransform)) as AnchorTransform;

            return _instance;
        }
    }



    [SyncVar]
    public Vector3 anchorPosition;
    [SyncVar]
    public Vector3 anchorRotation;
    [SyncVar]
    public float anchorScale = 1;


    public Vector3 AnchorPosition
    {
        get { return anchorPosition; }
        set { anchorPosition = value; }
    }

    public Vector3 AnchorRotation
    {
        get { return anchorRotation; }
        set { anchorRotation = value; }
    }

    public float AnchorScale
    {
        get { return anchorScale; }
        set { anchorScale = value; }
    }

    public void ApplyScale()
    {
        transform.localScale += new Vector3(anchorScale, anchorScale, anchorScale);
    }
}
