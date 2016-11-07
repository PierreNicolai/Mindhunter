using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{
	public float viewRadius;
	[Range (0, 360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform> ();

	public MeshFilter viewMeshFilter;
	Mesh viewMesh;

	public float meshResolution;
	public int  edgeResolveIteration;
	public float edgeThreshold;

	void Start ()
	{
		viewMesh = new Mesh ();
		viewMesh.name = "View Mesh";
		viewMeshFilter.mesh = viewMesh;
        // Start looking for targets
		StartCoroutine ("FindTargetsWithDelay", 0.2f);
	}

	IEnumerator FindTargetsWithDelay (float delay)
	{
		while (true) {
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}

	void LateUpdate ()
	{
		DrawFieldOfView ();
	}

	void FindVisibleTargets ()
	{
		visibleTargets.Clear ();
		Collider[] targetInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);
		for (int i = 0; i < targetInViewRadius.Length; i++) {
			Transform target = targetInViewRadius [i].transform;
			Vector3 directionToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle (transform.forward, directionToTarget) < viewAngle / 2) {
				float distanceToTarget = Vector3.Distance (transform.position, target.position);
				if (!Physics.Raycast (transform.position, directionToTarget, distanceToTarget, obstacleMask)) {
					visibleTargets.Add (target);
				}
			}
		}
	}

	public Vector3  DirectionFromAngle (float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal) {	
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3 (Mathf.Sin (angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos (angleInDegrees * Mathf.Deg2Rad));
	}

	public void DrawFieldOfView ()
	{
		int stepCount = Mathf.RoundToInt (viewAngle * meshResolution);
		float stepAngleSize = viewAngle / stepCount;
		List<Vector3> viewPoints = new List<Vector3> ();
		ViewCastInfo oldViewCast = new ViewCastInfo();
		for (int i = 0; i <= stepCount; i++) {
			float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
//			Debug.DrawLine (transform.position, transform.position + DirectionFromAngle (angle, true) * viewRadius, Color.red);			
			ViewCastInfo newViewCastInfo = ViewCast (angle);
			if(i >  0) {
				bool edgeThresholdExceeded = Mathf.Abs(oldViewCast.distance - newViewCastInfo.distance ) > edgeThreshold;
				if(oldViewCast.hit != newViewCastInfo.hit  ||  (oldViewCast.hit && newViewCastInfo.hit && edgeThresholdExceeded)) {
					EdgeInfo edge = FindEdge(oldViewCast, newViewCastInfo);
					if(edge.pointA != Vector3.zero) {
						viewPoints.Add(edge.pointA);
					}
					if(edge.pointB != Vector3.zero) {
						viewPoints.Add(edge.pointB);
					}
				}
			}
			viewPoints.Add (newViewCastInfo.point);
			oldViewCast = newViewCastInfo;
		}

		int vertexCount = viewPoints.Count + 1;
		Vector3[] vertices = new Vector3[vertexCount];
		int[] triangles = new int[(vertexCount - 2) * 3];

		vertices [0] = Vector3.zero;

		for (int i = 0; i < vertexCount - 1; i++) {
			vertices [i + 1] = transform.InverseTransformPoint(viewPoints [i]);

			if (i < vertexCount - 2) {
				triangles [i * 3] = 0;
				triangles [i * 3 + 1] = i + 1;
				triangles [i * 3 + 2] = i + 2;
			}
		}
		viewMesh.Clear ();

		viewMesh.vertices = vertices;
		viewMesh.triangles = triangles;
		viewMesh.RecalculateNormals ();
	}

	EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast) {
		float minAngle = minViewCast.angle;
		float maxAngle = maxViewCast.angle;
		Vector3 minPoint  = Vector3.zero;
		Vector3 maxPoint  = Vector3.zero;

		for (int i = 0; i < edgeResolveIteration; i++) {
			float angle = (minAngle + maxAngle) / 2;
			ViewCastInfo newViewCastInfo = ViewCast(angle);

			bool edgeThresholdExceeded = Mathf.Abs(minViewCast.distance - newViewCastInfo.distance ) > edgeThreshold;
			if(newViewCastInfo.hit == minViewCast.hit && !edgeThresholdExceeded) {
				minAngle = angle;
				minPoint = newViewCastInfo.point;
			}else {
				maxAngle = angle;
				maxPoint =  newViewCastInfo.point;
			}
		}
		return new EdgeInfo(minPoint , maxPoint);
	}

	ViewCastInfo ViewCast (float globalAngle)
	{
		Vector3 direction = DirectionFromAngle (globalAngle, true);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, direction, out hit, viewRadius, obstacleMask)) {
			return new ViewCastInfo (true, hit.point, hit.distance, globalAngle);
		} else {
			return new ViewCastInfo (false, transform.position + direction * viewRadius, viewRadius, globalAngle);
		}
	}

	public struct ViewCastInfo
	{
		public bool hit;
		public Vector3 point;
		public float distance;
		public float angle;

		public ViewCastInfo (bool _hit, Vector3 _point, float _disance, float _angle)
		{
			hit = _hit;
			point = _point;
			distance = _disance;
			angle = _angle;
		}
	}

	public struct EdgeInfo {
		public Vector3 pointA;
		public Vector3 pointB;

		public EdgeInfo(Vector3 _pointA, Vector3 _pointB) {
			pointA = _pointA;
			pointB = _pointB;
		}
	}
}
