using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour
{

    [System.Serializable]
    public class PositionSettings
    {        
        public float minDistanceFromTarget = 0.3f;
        public float distanceFromTarget = -2.4f;
        public float maxZoom = -2;
        public float minZoom = -15;
        public float smooth = 0.05f;
        public bool smoothFollow = true;
        [HideInInspector]
        public float adjustmentDistance = -2.4f;
    }

    [System.Serializable] 
    public class OrbitSettings
    {
        public float xRotation = -20;
        public float yRotation = -180;
        public float maxXRotation = 10;
        public float minXRotation = -85;
        public float vOrbitSmooth = 150;
        public float hOrbitSmooth = 150;
    }

    [System.Serializable]
    public class DebugSettings
    {
        public bool drawDesiredCollisionsLines = true;
        public bool drawAdjustedColliionsLines = true;
    }

    public Transform target;

    public PositionSettings position = new PositionSettings();
    public OrbitSettings orbit = new OrbitSettings();
    public DebugSettings debug = new DebugSettings();
    public CollisionHandler collision = new CollisionHandler();

    Vector3 targetPos = Vector3.zero;
    Vector3 destination = Vector3.zero;
    Vector3 adjustedDestination = Vector3.zero;
    Vector3 camVel = Vector3.zero;

    float vOrbitInput, hOrbitInput;

    // Use this for initialization
    void Start()
    {
        vOrbitInput = hOrbitInput = 0;

        MoveToTaget();

        collision.Initialize(Camera.main);
        collision.UpdateCameraClipPoints(transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
        collision.UpdateCameraClipPoints(destination, transform.rotation, ref collision.desiredCameraClipPoints);
    }

    void Update()
    {
        GetInput();
    }
    // Update is called once per frame
    void FixedUpdate()
    {		
        //Moving
        MoveToTaget();
        //Rotating
        LookAtTarget();
        //Orbit
        OrbitTarget();

        collision.UpdateCameraClipPoints(transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
        collision.UpdateCameraClipPoints(destination, transform.rotation, ref collision.desiredCameraClipPoints);

        for (int i = 0; i < 5; i++)
        {			
            if (debug.drawDesiredCollisionsLines)
            {
                Debug.DrawLine(targetPos, collision.desiredCameraClipPoints[i], Color.white);
            }
            if (debug.drawAdjustedColliionsLines)
            {
                Debug.DrawLine(targetPos, collision.adjustedCameraClipPoints[i], Color.green);
            }
        }

        collision.CheckCollding(targetPos); //using raycasts here
        position.adjustmentDistance = collision.GetAdjustedDistanceWithRayFrom(targetPos);
    }

    void GetInput()
    {
    	
//        hOrbitInput = CrossPlatformInputManager.GetAxis("Right Stick X Axis");
//        vOrbitInput = CrossPlatformInputManager.GetAxis("Right Stick Y Axis");
 	hOrbitInput = CrossPlatformInputManager.GetAxis("Mouse X");
        vOrbitInput = -CrossPlatformInputManager.GetAxis("Mouse Y");
    }

    void MoveToTaget()
    {
        targetPos = target.position;
        destination = Quaternion.Euler(orbit.xRotation, orbit.yRotation, 0f) * Vector3.forward * position.distanceFromTarget;
        destination += targetPos;

        if (collision.colliding)
        {
            adjustedDestination = Quaternion.Euler(orbit.xRotation, orbit.yRotation, 0f) * Vector3.forward * position.adjustmentDistance;
            adjustedDestination += targetPos;

            if(position.smoothFollow) {
                transform.position = Vector3.SmoothDamp(transform.position, adjustedDestination, ref camVel, position.smooth);
            }else {
                
            }
        }
        else
        {
            if(position.smoothFollow) {
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVel, position.smooth);
            }else {
                transform.position = destination ;  
            }            
        }
    }

    void LookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100f  * Time.deltaTime);
    }

    void OrbitTarget()
    {
        orbit.xRotation += vOrbitInput * orbit.vOrbitSmooth * Time.deltaTime;
        orbit.yRotation += hOrbitInput * orbit.hOrbitSmooth * Time.deltaTime;

        orbit.xRotation = Mathf.Clamp(orbit.xRotation, orbit.minXRotation, orbit.maxXRotation);
    }

    // Handle collisions of the camera
    [System.Serializable]
    public class CollisionHandler
    {
        public LayerMask collisionMask;

        [HideInInspector]
        public bool colliding = false;
        [HideInInspector]
        public Vector3[] adjustedCameraClipPoints;
        [HideInInspector]
        public Vector3[] desiredCameraClipPoints;


        public Camera camera;

        public void Initialize(Camera _camera)
        {
            camera = _camera;
            adjustedCameraClipPoints = new Vector3[5];
            desiredCameraClipPoints = new Vector3[5];
        }

        public void UpdateCameraClipPoints(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] intoArray)
        {
            if (!camera)
                return;

            //Clear the contents of intoArray

            intoArray = new Vector3[5];

            float z = camera.nearClipPlane;
            float x = Mathf.Tan(camera.fieldOfView / 3.41f) * z;
            float y = x / camera.aspect;

            //top left
            intoArray[0] = (atRotation * new Vector3(-x, y, z)) + cameraPosition;
            //top right
            intoArray[1] = (atRotation * new Vector3(x, -y, z)) + cameraPosition;
            //bottom left
            intoArray[2] = (atRotation * new Vector3(-x, -y, z)) + cameraPosition;
            //bottome right
            intoArray[3] = (atRotation * new Vector3(x, -y, z)) + cameraPosition;
            //camera's position
            intoArray[4] = cameraPosition - camera.transform.forward;
        }

        bool CollisionDetectedClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
        {
            for (int i = 0; i < clipPoints.Length; i++)
            {
                Ray ray = new Ray(fromPosition, clipPoints[i] - fromPosition);
                float distance = Vector3.Distance(clipPoints[i], fromPosition);
                if (Physics.Raycast(ray, distance, collisionMask))
                {
                    return true;
                }
            }
            return false;
        }

        public float GetAdjustedDistanceWithRayFrom(Vector3 from)
        {
            float distance = -1;

            for (int i = 0; i < desiredCameraClipPoints.Length; i++)
            {

                Ray ray = new Ray(from, desiredCameraClipPoints[i] - from);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (distance == -1)
                    {
                        distance = hit.distance;
                    }
                    else
                    {
                        if (hit.distance < distance)
                        {
                            distance = hit.distance;
                        }
                    }
                }
            }

            if (distance == -1)
                return 0;
            return distance;
        }

        public void CheckCollding(Vector3 targetPosition)
        {
            if (CollisionDetectedClipPoints(desiredCameraClipPoints, targetPosition))
            {
                colliding = true;
            }
            else
            {
                colliding = false;
            }
        }
    }
}
