// This script calculates the 3D vectors' value needed for player movement

using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float rotate_sensitivity = 3f;
	
	private PlayerMotor motor;
	
	void Start() {
		motor = GetComponent<PlayerMotor>();
		
		
	}
	
	void Update(){
		// Calculate movement velocity as a 3D vetor
		
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw("Vertical");
		
		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;
		
		//Final movement 3D vector
		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;
		
		//Apply movement
		motor.Move(_velocity);
		
		//Calculate rotation as 3D vector
		float y_Rot = Input.GetAxisRaw("Mouse X");
		
		Vector3 _rotation = new Vector3 (0f,y_Rot,0f) * rotate_sensitivity;
		
		//Apply rotation 
		motor.Rotate(_rotation);
		
		//Calculate camera rotation as 3D vector 
		float x_Rot = Input.GetAxisRaw("Mouse Y");
		
		Vector3 _cameraRotation = new Vector3 (-(x_Rot),0f,0f) * rotate_sensitivity;
				
		//Apply camera rotation 
		motor.RotateCamera(_cameraRotation);
		
		
	}
}
