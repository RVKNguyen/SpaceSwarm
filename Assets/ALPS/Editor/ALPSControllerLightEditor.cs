/************************************************************************
	ALPSControllerLightEditor is a custom editor for ALPSControllerLight class
	
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
using UnityEditor;

[System.Serializable]
[CustomEditor(typeof(ALPSControllerLight))]
public class ALPSControllerLightEditor : Editor {
	
	//=====================================================================================================
	// Attributes
	//=====================================================================================================
	
	/**Public**/
	public ALPSConfig deviceConfig;
	public ALPSControllerLight controller;
	
	public Device Device{
		get{
			return deviceConfig.deviceName;
		}
		set{
			if(deviceConfig.deviceName != value){
				controller.SetDevice(value);
				OnEnable();
			}
		}
	}
	
	//=====================================================================================================
	// Functions
	//=====================================================================================================
	
	public void OnEnable()
	{
		controller = (ALPSControllerLight)target;
		deviceConfig = (controller.deviceConfig == null)? ALPSDevice.GetConfig(Device.DEFAULT):controller.deviceConfig;
		controller.deviceConfig = deviceConfig;
	}
	
	public override void OnInspectorGUI(){
		
		//Device
		Device = (Device)EditorGUILayout.EnumPopup("Device:",Device);
		
		//Stereo distance
		deviceConfig.ILD = EditorGUILayout.FloatField (new GUIContent("ILD","Inter Lens Distance in millimeter. This is the distance between both cameras and this should match the IPD. Can be tweaked to increase or decrease the stereo effect."),deviceConfig.ILD);

		//Field Of View
		deviceConfig.fieldOfView = EditorGUILayout.Slider ("Vertical FOV",deviceConfig.fieldOfView, 1, 180); 

		if (GUI.changed) {
			controller.ClearDirty();
			EditorUtility.SetDirty(target);
		}
	}
}