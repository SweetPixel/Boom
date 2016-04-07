using UnityEngine;
using System.Collections;
using CnControls;

public class PlatformCharacterTest : MonoBehaviour {
	public float MovementSpeed = 10f;
	
	private Transform _mainCameraTransform;
	private Transform _transform;
	private CharacterController _characterController;
	
	void OnStart()
	{
		//_mainCameraTransform = Camera.main.GetComponent<Transform>();
		//_characterController = GetComponent<CharacterController>();
		_transform = GetComponent<Transform>();
	}
	
	void Update()
	{
		// Just use CnInputManager. instead of Input. and you're good to go
		/*var inputVector = new Vector3(CnInputManager.GetAxis("Horizontal"), transform.position.y);
		Vector3 movementVector = Vector3.zero;
		
		// If we have some input
		if (inputVector.sqrMagnitude > 0.001f)
		{
			//movementVector = _mainCameraTransform.TransformDirection(inputVector);
			movementVector.y = 0f;
			//movementVector.Normalize();
			_transform.forward = movementVector;
		}
		
		movementVector += Physics.gravity;
		//_characterController.Move(movementVector * Time.deltaTime);*/
		Debug.Log("Pirate is not runnning");



		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * MovementSpeed);
	}
}
