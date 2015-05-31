/************************************************************************
	ALPSControllerLight is the main class for non Pro license holders
	
    Copyright (C) 2015  ALPS VR.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

************************************************************************/

using UnityEngine;
using System.Collections;

[System.Serializable]
public class ALPSControllerLight : MonoBehaviour {

	//=====================================================================================================
	// Attributes
	//=====================================================================================================

	/**Public**/
	//The current device configuration
	public ALPSConfig deviceConfig = ALPSDevice.GetConfig(Device.DEFAULT);

	//One camera for each eye
	public GameObject cameraLeft;
	public GameObject cameraRight;

	//Head represents user's head
	public GameObject head;

	//Vector between eyes and the pivot point (neck)
	public Vector2 neckToEye;

	//=====================================================================================================
	// Functions
	//=====================================================================================================

	/// <summary>
	/// Initializes side-by-side rendering and head tracking.
	/// </summary>
	public void Awake () {
		//Adding head
		head = GameObject.Find("ALPSHead");
		if(head == null) head = new GameObject("ALPSHead");
		head.transform.parent = transform;
		head.transform.position = transform.position;

		#if UNITY_EDITOR
			head.AddComponent (typeof(MouseLook));
		#elif UNITY_ANDROID
			head.AddComponent(typeof(ALPSGyro));
		#endif

		for (var i=0; i<2; i++) {
			bool left = (i==0);
			GameObject OneCamera = GameObject.Find(left?"CameraLeft":"CameraRight");
			if(OneCamera == null) OneCamera = new GameObject(left?"CameraLeft":"CameraRight");
			OneCamera.GetComponent<Camera>().rect = new Rect ((left?0:0.5f),0,0.5f,1);
			OneCamera.transform.parent = head.transform;

			Vector3 OneCamPos = head.transform.position;
			OneCamPos.z = ALPSConfig.neckPivotToEye.x * 0.001f;
			OneCamPos.y = ALPSConfig.neckPivotToEye.y * 0.001f;
			OneCamera.transform.position = OneCamPos;

			if(left)cameraLeft = OneCamera;
			else cameraRight = OneCamera;
		}


		AudioListener[] listeners = FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
		if (listeners.Length < 1) {
			gameObject.AddComponent (typeof(AudioListener));
		}

		ClearDirty ();
	}

	/// <summary>
	/// Resets all the settings and applies the current DeviceConfig
	/// </summary>
	public void ClearDirty(){
		if (cameraLeft != null && cameraRight != null) {
			cameraLeft.transform.localPosition = new Vector3 (deviceConfig.ILD * -0.0005f, ALPSConfig.neckPivotToEye.y * 0.001f, ALPSConfig.neckPivotToEye.x * 0.001f);
			cameraRight.transform.localPosition = new Vector3 (deviceConfig.ILD * 0.0005f, ALPSConfig.neckPivotToEye.y * 0.001f, ALPSConfig.neckPivotToEye.x * 0.001f);

			Vector3 camLeftPos = cameraLeft.transform.localPosition; 
			camLeftPos.x = -deviceConfig.ILD * 0.0005f;
			cameraLeft.transform.localPosition = camLeftPos;
		
			Vector3 camRightPos = cameraRight.transform.localPosition;
			camRightPos.x = deviceConfig.ILD * 0.0005f;
			cameraRight.transform.localPosition = camRightPos;

			cameraLeft.GetComponent<Camera>().fieldOfView = deviceConfig.fieldOfView;
			cameraRight.GetComponent<Camera>().fieldOfView = deviceConfig.fieldOfView;
		}
	}

	/// <summary>
	/// Sets a new device configuration.
	/// </summary>
	// <param name="_device">Name of the device.</param>
	public void SetDevice(Device _device){
		deviceConfig = ALPSDevice.GetConfig (_device);
		ClearDirty ();
	}

	/// <summary>
	/// Copy camera settings to left and right cameras. Will overwrite culling masks.
	/// </summary>
	/// <param name="_cam">The camera from which you want to copy the settings.</param>
	public void SetCameraSettings(Camera _cam){
		cameraLeft.GetComponent<Camera>().CopyFrom (_cam);
		cameraRight.GetComponent<Camera>().CopyFrom (_cam);
		cameraLeft.GetComponent<Camera>().rect = new Rect (0,0,0.5f,1);
		cameraRight.GetComponent<Camera>().rect = new Rect (0.5f,0,0.5f,1);
	}
	
	/// <summary>
	/// Adds left and right layers to the existing culling masks for left and right cameras.
	/// </summary>
	/// <param name="_leftLayer">Name of the layer rendered by the left camera.</param>
	/// <param name="_rightLayer">Name of the layer rendered by the right camera.</param>
	public int SetStereoLayers(string _leftLayer, string _rightLayer){
		int leftLayer = LayerMask.NameToLayer (_leftLayer);
		int rightLayer = LayerMask.NameToLayer (_rightLayer);
		if (leftLayer < 0 && rightLayer < 0) return -1;

		cameraLeft.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer(_leftLayer);
		cameraLeft.GetComponent<Camera>().cullingMask &=  ~(1 << LayerMask.NameToLayer(_rightLayer));

		cameraRight.GetComponent<Camera>().cullingMask |= 1 << LayerMask.NameToLayer(_rightLayer);
		cameraRight.GetComponent<Camera>().cullingMask &=  ~(1 << LayerMask.NameToLayer(_leftLayer));

		return 0;
	}

	/// <summary>
	/// Returns point of view position. This can be useful for setting up a Raycast.
	/// </summary>
	public Vector3 PointOfView(){
		//returns current position plus NeckToEye vector
		return new Vector3(transform.position.x,transform.position.y + neckToEye.y*0.001f,transform.position.z + neckToEye.x*0.001f);
	}

	/// <summary>
	/// Returns right camera forward direction vector. This can be useful for setting up a Raycast.
	/// </summary>
	public Vector3 RaycastForwardDirection(){
		return cameraRight.GetComponent<Camera>().transform.forward;
	}
	
	/// <summary>
	/// Returns the position of either the left camera, the right camera or the center point. This may be useful for setting up a Raycast.
	/// </summary>
	/// <param name="_origin">Either "left", "right" or "center".</param>
	public Vector3 RaycastOrigin(string _origin){
		Vector3 origin = new Vector3();
		switch(_origin.ToUpper ()){
		case "LEFT":
			origin = cameraLeft.transform.position;
			break;
		case "RIGHT":
			origin = cameraRight.transform.position;
			break;
		case "CENTER":
			origin = PointOfView();
			break;
		default:
			Debug.LogError("RaycastOrigin(string _origin): You can only choose 'left', 'right' or 'center' as a Raycast origin. "+_origin+" is not an expected value");
			break;
		}
		return origin;
	}
	
	/// <summary>
	/// Sets the vertical field of view for both cameras.
	/// </summary>
	/// <param name="_fov">The vertical fiel of view to be set (between 1 and 180).</param>
	public void setFieldOfView(float _fov){
		if (_fov < 1 || _fov > 180) {
			Debug.LogWarning("setFieldOfView(float _fov): Field of view must range between 1 and 180");
			_fov = (_fov<1)?1:180;
		}
		deviceConfig.fieldOfView = _fov;
		ClearDirty ();
	}

	/// <summary>
	/// Returns left and right cameras.
	/// </summary>
	public Camera[] GetCameras(){
		Camera[] cams = {cameraLeft.GetComponent<Camera>(), cameraRight.GetComponent<Camera>()};
		return cams;
	}
}
