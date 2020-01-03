using System.Collections;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.CloudAnchors;
using UnityEngine.Networking;
#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class GeneratorMap : NetworkBehaviour
{
    [Header("ARCore")]
    public Camera mainCamera;
    public ARCoreWorldOriginHelper ARCoreWorldOriginHelper;

    [Header("Prefabs")]
    public GameObject positionAnchorPrefab;
    public GameObject sclaeAnchorPrefab;
    public GameObject boardMapPrefab;
    public GameObject gamestartPrefab;

    [Header("Effect")]
    public ParticleSystem particle;
    public AudioSource particleAudio;

    [SyncVar]
    public bool isGenerate = false;

    private GameObject boardMap;
    private GameObject gameStart;
    private GameObject positionAnchorObject;
    private GameObject scaleAnchorObject;

    private bool isSetPosition = false;
    private bool isSetScale = false;

    ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponentInChildren<ParticleSystem>();

            return _CachedSystem;
        }
    }
    private ParticleSystem _CachedSystem;


    void Update()
    {


        if (Input.touchCount < 1)
        {
            return;
        }



        Touch touch;

        TrackableHit arcoreHitResult = new TrackableHit();


        if (Input.touchCount < 2 && !isSetPosition)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (ARCoreWorldOriginHelper.Raycast(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y,
                            TrackableHitFlags.PlaneWithinPolygon, out arcoreHitResult))
                {
                    positionAnchorObject.transform.position = arcoreHitResult.Pose.position;
                }
            }
        }
        else if (Input.touchCount >= 2 && isSetPosition)
        {

            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            Vector2 firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            Vector2 secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

            float newTouchMag = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
            float oldTouchMag = (firstTouch.position - secondTouch.position).magnitude;

            float touchMagDiff = oldTouchMag - newTouchMag;

            if (touchMagDiff != 0)
                AnchorTransform.Instance.AnchorScale += touchMagDiff * 0.1f;




            scaleAnchorObject.transform.localScale += new Vector3(touchMagDiff * 0.1f, touchMagDiff * 0.1f, 0);

        }

    }

    public void CreateMap()
    {
        positionAnchorObject = Instantiate(positionAnchorPrefab, Vector3.zero, positionAnchorPrefab.transform.rotation);
        GameObject.Find("GameScreen").transform.Find("ApplyPosition").gameObject.SetActive(true);
        GameObject.Find("GameScreen").transform.Find("Reset").gameObject.SetActive(true);

    }

    public void SetPosition()
    {

        AnchorTransform.Instance.AnchorPosition = positionAnchorObject.transform.position;

        isSetPosition = true;

        Destroy(positionAnchorObject);

        GameObject.Find("GameScreen").transform.Find("ApplyPosition").gameObject.SetActive(false);
        GameObject.Find("GameScreen").transform.Find("ApplyScale").gameObject.SetActive(true);


        scaleAnchorObject = Instantiate(sclaeAnchorPrefab, AnchorTransform.Instance.AnchorPosition, positionAnchorPrefab.transform.rotation);



    }
    public void SetScale()
    {

        isSetScale = true;

        Destroy(scaleAnchorObject);

        GameObject.Find("GameScreen").transform.Find("Reset").gameObject.SetActive(false);
        GameObject.Find("GameScreen").transform.Find("ApplyScale").gameObject.SetActive(false);

        //particle.transform.position = AnchorTransform.Instance.AnchorPosition;
        //particle.transform.localScale += new Vector3(AnchorTransform.Instance.AnchorScale, 0, AnchorTransform.Instance.AnchorScale);

        AnchorTransform.Instance.ApplyScale();

        OnAnimation();

    }



    public void ResetAnchor()
    {
      
    }


    public void OnAnimation()
    {
        boardMap = Instantiate(boardMapPrefab, AnchorTransform.Instance.AnchorPosition /*- new Vector3(0, 0.1f, 0)*/, boardMapPrefab.transform.rotation);

        isGenerate = true;

#pragma warning disable 618
        NetworkServer.Spawn(boardMap);
#pragma warning restore 618

    }

    IEnumerator BoardMapAnimation()
    {
        while (true)
        {
            if (boardMap.transform.position.y < 0)
                boardMap.transform.Translate(0, 0.002f, 0);

            yield return new WaitForSeconds(0.1f);
        }
    }


}
