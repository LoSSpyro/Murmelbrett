using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public float lag = 0f;
	public float sensitivity = 1f;

	public float maxXRotation = 45f;
	public float maxZRotation = 45f;

	private float xRot = 0f;
	private float zRot = 0f;

	private bool mouse = true;
	private string AxisX, AxisY;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (mouse) {
			AxisX = "Mouse X";
			AxisY = "Mouse Y";
		} else {
			AxisX = "Horizontal";
			AxisY = "Vertical";
		}

		float h = Input.GetAxisRaw (AxisX);
		float v = Input.GetAxisRaw (AxisY);
		StartCoroutine (Lag (h, v));
	}

	IEnumerator Lag (float h, float v) {
		
		yield return new WaitForSeconds (lag / 1000f);

		zRot += -h  * sensitivity/1000;
		xRot += v  * sensitivity/1000;

		zRot = Mathf.Clamp (zRot, -maxZRotation, maxZRotation);
		xRot = Mathf.Clamp (xRot, -maxXRotation, maxXRotation);


		Vector3 newRotation = (Vector3.right * xRot + Vector3.forward * zRot);

		transform.eulerAngles = newRotation;
	
	}

	public void UpdateSensitivity(float newValue) {
		sensitivity = newValue;
	}

	public void UpdateLag(float newValue) {
		lag = newValue;
	}

	public void ChangeInput() {
		mouse = !mouse;
	}
}
