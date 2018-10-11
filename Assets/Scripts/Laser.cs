using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float updateFrequency = 0.1f;
    public int laserDistance;
    public string bounceTag;
    public string splitTag;
    public string spawnedBeamTag;
    public int maxBounce;
    public int maxSplit;
    public GameObject Player;
    public int LaserLayerMask;
    private float timer = 0;
    private LineRenderer mLineRenderer;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        LaserLayerMask = 1 << 9;
        mLineRenderer = gameObject.GetComponent<LineRenderer>();
        StartCoroutine(RedrawLaser());
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != spawnedBeamTag)
        {
            if (timer >= updateFrequency)
            {
                timer = 0;
                //Debug.Log("Redrawing laser");
                foreach (GameObject laserSplit in GameObject.FindGameObjectsWithTag(spawnedBeamTag))
                    Destroy(laserSplit);

                StartCoroutine(RedrawLaser());
            }
            else
            {
                mLineRenderer = gameObject.GetComponent<LineRenderer>();
                StartCoroutine(RedrawLaser());
            }
            timer += Time.deltaTime;
        }
    }

    IEnumerator RedrawLaser()
    {
        //Debug.Log("Running");
        int laserSplit = 1; //How many times it got split
        int laserReflected = 1; //How many times it got reflected
        int vertexCounter = 1; //How many line segments are there
        bool loopActive = true; //Is the reflecting loop active?

        Vector3 laserDirection = transform.forward; //direction of the next laser
        Vector3 lastLaserPosition = transform.position; //origin of the next laser

        mLineRenderer.positionCount = 2;
        mLineRenderer.SetPosition(0, transform.position);
        mLineRenderer.SetPosition(1, transform.position + 5 * transform.forward);
        RaycastHit hit;

        while (loopActive)
        {
            Debug.Log("Physics.Raycast(" + lastLaserPosition + ", " + laserDirection + ", out hit , " + laserDistance + ")");
            //Debug.DrawRay(lastLaserPosition, laserDirection*1000,Color.green);
            if (Physics.Raycast(lastLaserPosition, laserDirection, out hit, laserDistance,LaserLayerMask) && ((hit.transform.gameObject.tag == bounceTag) || (hit.transform.gameObject.tag == splitTag)))
            {
                Debug.Log("Bounce");
                laserReflected++;
                vertexCounter += 3;
                mLineRenderer.positionCount = vertexCounter;
                mLineRenderer.SetPosition(vertexCounter - 3, Vector3.MoveTowards(hit.point, lastLaserPosition, 0.01f));
                mLineRenderer.SetPosition(vertexCounter - 2, hit.point);
                mLineRenderer.SetPosition(vertexCounter - 1, hit.point);
                mLineRenderer.startWidth = .2f;
                mLineRenderer.endWidth = .2f;
                lastLaserPosition = hit.point;
                Vector3 prevDirection = laserDirection;
                laserDirection = Vector3.Reflect(laserDirection, hit.normal);

                if (hit.transform.gameObject.tag == splitTag)
                {
                    //Debug.Log("Split");
                    if (laserSplit >= maxSplit)
                    {
                        Debug.Log("Max split reached.");
                    }
                    else
                    {
                        //Debug.Log("Splitting...");
                        laserSplit++;
                        Object go = Instantiate(gameObject, hit.point, Quaternion.LookRotation(prevDirection));
                        go.name = spawnedBeamTag;
                        ((GameObject)go).tag = spawnedBeamTag;
                    }
                }
            }
            else
            {
                //Debug.Log("No Bounce");
                laserReflected++;
                vertexCounter++;
                mLineRenderer.positionCount = vertexCounter;
                Vector3 lastPos = lastLaserPosition + (laserDirection.normalized * laserDistance);
                //Debug.Log("InitialPos " + lastLaserPosition + " Last Pos" + lastPos);
                if (Vector3.Dot(lastPos, Player.transform.position + Player.transform.forward * 2) >= 0)
                {
                    mLineRenderer.SetPosition(vertexCounter - 1, lastLaserPosition + (laserDirection.normalized * laserDistance));
                }
                else
                {
                    mLineRenderer.SetPosition(vertexCounter - 1, lastLaserPosition);
                }
                loopActive = false;
            }
            if (laserReflected > maxBounce)
                loopActive = false;
        }

        yield return new WaitForEndOfFrame();
    }
    /*public float speed = 15.0f;
    public float lifetime = 120.0f;
    private bool HitMirror = false;
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime<0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Rigidbody LaserRB = GetComponent<Rigidbody>();
        LaserRB.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mirror"))
        {
            if (!HitMirror)
            {
                Vector3 ReflectionAngle = Vector3.Reflect(transform.forward, other.transform.forward);
                transform.forward = ReflectionAngle;
                HitMirror = true;
            }
        }
        if (other.gameObject.CompareTag("RefractionObject"))
        {
            float IndexOfIncidence = 1;
            float IndexOfRefraction = 4;
            if (!other.gameObject.GetComponent<RefractObject>().MirrorHit)
            {
                Vector3 ReflectionAngle = Vector3.Reflect(transform.forward, other.transform.forward);
                float AngleBetweenReflectedPoints = Vector3.Angle(transform.forward, ReflectionAngle);
                float AngleOfIncidence = (180 - AngleBetweenReflectedPoints) / 2;
                Debug.Log(AngleOfIncidence);
                float AngleOfRefraction = Mathf.Asin(IndexOfIncidence * Mathf.Sin((AngleOfIncidence * Mathf.PI) / 180) / IndexOfRefraction);
                float AngleOfRefractionInDegrees = (Mathf.Asin(AngleOfRefraction) * 180) / Mathf.PI;
                Vector3 N = other.transform.forward;
                Vector3 s1 = transform.forward;
                Vector3 RefractionDir = (IndexOfIncidence / IndexOfRefraction) * (Vector3.Cross(N, Vector3.Cross(-N, s1))) - N * Mathf.Sqrt(1 - Mathf.Pow(IndexOfIncidence / IndexOfRefraction, 2) * Vector3.Dot(Vector3.Cross(N, s1), Vector3.Cross(N, s1)));
                transform.forward = RefractionDir;
                Debug.Log(AngleOfRefractionInDegrees);
                //Vector3 RefractionAngle = ;
                //transform.forward = ReflectionAngle;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mirror"))
        {
            HitMirror = false;
        }
    }*/
}
