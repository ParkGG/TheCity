using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.Networking;

#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class TouchController : NetworkBehaviour
{

    public Vector3 prePos;
    public Vector3 nowPos;
    public Vector3 movePos;

    public Camera mainCamera;


    private void Start()
    {
        mainCamera = GameObject.Find("ARCore Root").GetComponentInChildren<Camera>();
    }

    void Update()
    {

        if (Input.touchCount < 1)
        {
            return;
        }


        Touch touch = Input.GetTouch(0);
        Ray ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;

        if (touch.phase == TouchPhase.Began)
        {
            prePos = touch.position - touch.deltaPosition;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Building")
                {
                }
            }
        }

        else if (touch.phase == TouchPhase.Stationary)
        {
        }

        else if (touch.phase == TouchPhase.Moved)
        {
            nowPos = touch.position - touch.deltaPosition;
            movePos = (Vector3)(prePos - nowPos) / 1000.0f;
            prePos = touch.position - touch.deltaPosition;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "BuildPlace")
                {
                }

            }


        }

        else if (touch.phase == TouchPhase.Ended)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    string hitObject = hit.collider.gameObject.name;

                    CmdCall(hitObject);
                }
            }

        }
    }

    [Command]
    public void CmdCall(string hit)
    {
        RpcActive(hit);
    }


    [ClientRpc]
    public void RpcActive(string hit)
    {

        GameObject hitObject = GameObject.Find(hit).transform.gameObject;
        Debug.Log(hitObject.name);
        string hitName = hitObject.name;

        int childCount = hitObject.transform.childCount;

        int touchCount = hitObject.GetComponent<TouchCount>().Counting;

        for (int ix = 0; ix < childCount; ++ix)
        {
            if (touchCount == 0)
            {
                if (hitObject.transform.GetChild(ix).name.Contains("Roads_Street_"))
                    if (!hitObject.transform.GetChild(ix).gameObject.activeSelf)
                        GameObject.Find(hitName).transform.GetChild(ix).gameObject.SetActive(true);

                if (hitObject.transform.GetChild(ix).name.Contains("FootPath_"))
                    if (!hitObject.transform.GetChild(ix).gameObject.activeSelf)
                        GameObject.Find(hitName).transform.GetChild(ix).gameObject.SetActive(true);

                if (hitObject.transform.GetChild(ix).name.Contains("Carbs_"))
                    if (!hitObject.transform.GetChild(ix).gameObject.activeSelf)
                        GameObject.Find(hitName).transform.GetChild(ix).gameObject.SetActive(true);

            }

            else if (touchCount == 1)
            {
                if (hitObject.transform.GetChild(ix).name.Contains("BnP_"))
                    if (!hitObject.transform.GetChild(ix).gameObject.activeSelf)
                        GameObject.Find(hitName).transform.GetChild(ix).gameObject.SetActive(true);

            }

            else if (touchCount == 2)
            {
                if (hitObject.transform.GetChild(ix).name.Contains("Skyscraper_"))
                    if (!hitObject.transform.GetChild(ix).gameObject.activeSelf)
                        GameObject.Find(hitName).transform.GetChild(ix).gameObject.SetActive(true);

                if (hitObject.transform.GetChild(ix).name.Contains("Props_Patch_"))
                    if (!hitObject.transform.GetChild(ix).gameObject.activeSelf)
                        GameObject.Find(hitName).transform.GetChild(ix).gameObject.SetActive(true);

            }


        }

        hitObject.GetComponent<TouchCount>().Counting += 1;

    }
}
