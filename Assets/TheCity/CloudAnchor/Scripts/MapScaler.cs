using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.localScale += new Vector3(AnchorTransform.Instance.anchorScale, AnchorTransform.Instance.anchorScale, AnchorTransform.Instance.anchorScale);

        StaticBatchingUtility.Combine(this.gameObject);
    }


}
