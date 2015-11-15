using UnityEngine;
using System.Collections;

public class ScMainCamera : MonoBehaviour {
	public const int Boundary = 5;
	public const int speed = 1;
	
	private int theScreenWidth;
	private int theScreenHeight;
	
	void Start() 
	{
		theScreenWidth = Screen.width;
		theScreenHeight = Screen.height;
	}
	
	void Update() 
	{
		float newx = transform.position.x;
		float newy = transform.position.y;
		if (Input.mousePosition.x > theScreenWidth - Boundary) {
			newx += speed * Time.deltaTime * Camera.main.orthographicSize;
		}
		if (Input.mousePosition.x < 0 + Boundary) {
			newx -= speed * Time.deltaTime * Camera.main.orthographicSize;
		}
		if (Input.mousePosition.y > theScreenHeight - Boundary) {
			newy += speed * Time.deltaTime * Camera.main.orthographicSize; 
		}
		if (Input.mousePosition.y < 0 + Boundary) {
			newy -= speed * Time.deltaTime * Camera.main.orthographicSize;
		}
		transform.position = new Vector3 (newx, newy, -10.0f);

		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			if (Camera.main.orthographicSize > 1) {
				Camera.main.orthographicSize--;
			}
		}
		
		if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			Camera.main.orthographicSize++;
		}

	}  
}
