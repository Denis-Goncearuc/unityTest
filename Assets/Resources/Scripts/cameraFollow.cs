using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
	public float distance = 20.0f;
	public float height = 5.0f;
	public float heightDamping = 2.0f;
    
 
	public float lookAtHeight = 0.0f;
 
	public Rigidbody parentRigidbody;
 
	public float rotationSnapTime = 0.3F;
 
	public float distanceSnapTime;
	public float distanceMultiplier;
 
	private Vector3 lookAtVector;
 
	private float usedDistance;
 
	float wantedRotationAngle;
	float wantedHeight;
    Vector2 wantedOffset;
 
	float currentRotationAngle;
	float currentHeight;
    Vector2 currentOffset;
 
	Quaternion currentRotation;
	Vector3 wantedPosition;
 
	private float yVelocity = 0.0F;
	private float zVelocity = 0.0F;
 
	void Start () {
 
		lookAtVector =  new Vector3(0,lookAtHeight,0);
 
	}
 
	void LateUpdate () {
        
		//target.position = coin.position + Offset;
        wantedHeight = target.position.y + height;
		
        
        currentHeight = transform.position.y;
 
		wantedRotationAngle = target.eulerAngles.y;
		currentRotationAngle = transform.eulerAngles.y;
 
		currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);
 
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
        
		wantedPosition = target.position;
		wantedPosition.y = currentHeight;
 
		usedDistance = Mathf.SmoothDampAngle(usedDistance, distance + (parentRigidbody.velocity.magnitude * distanceMultiplier), ref zVelocity, distanceSnapTime); 
 
		wantedPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance);
 
		transform.position = wantedPosition;
        
 
		transform.LookAt(target.position + lookAtVector);
 
	}
 
}
//     public Transform Player;
//     public Vector3 Offset;
//     public Vector3 eulerRotation;

//     // Update is called once per frame
//     void Update()
//     {
//         transform.position = Player.position + Offset;
//         eulerRotation = new Vector3(transform.localRotation.eulerAngles.x,
//                                             Mathf.LerpAngle(transform.localRotation.eulerAngles.y, Player.transform.localRotation.eulerAngles.y, 0.52f),
//                                             transform.localRotation.eulerAngles.z);
//         transform.rotation = Quaternion.Euler(eulerRotation);
//     }
// }
