/************************************************************************
	ALPSGUI provides a basic menu to choose a headset

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

public class ALPSGUI : MonoBehaviour {

	//=====================================================================================================
	// Attributes
	//=====================================================================================================

	/**Public**/
	public static ALPSController controller;

	/**Private**/
	private float beginX;
	private float endX;
	private float maxOffset;
	private bool GUIVisible;
	private bool GUIMenu;
	private bool GUIDeviceSelection;
	private bool GUICustomConfiguration;
	private bool showing;
	private bool hiding;
	private GUISkin ALPSSkin;

	//=====================================================================================================
	// Functions
	//=====================================================================================================

	/// <summary>
	/// Initializes device selection menu.
	/// </summary>
	public void Start(){
		beginX = 0;
		endX = 0;
		maxOffset = -ALPSController.screenWidthPix*0.25f;
		GUIVisible = false;
		GUIMenu = true;
		GUIDeviceSelection = false;
		GUICustomConfiguration = false;
		showing = false;
		hiding = false;
		ALPSSkin = Resources.Load ("ALPSSkin") as GUISkin;
		ALPSSkin.box.overflow.right = (int) maxOffset-1;
		ALPSSkin.button.overflow.right = (int) maxOffset-1;
		ALPSSkin.box.contentOffset = new Vector2((int) maxOffset-1,0);
		ALPSSkin.button.contentOffset = new Vector2((int) maxOffset-1,0);
	}

	/// <summary>
	/// Updates device selection menu.
	/// </summary>
	public void Update() {
		if(Input.touchCount > 0){
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				beginX = Input.GetTouch (0).position.x;
			} else if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				endX = Input.GetTouch (0).position.x;		
				if (endX - beginX >= 150) {
					SwipeRight ();
				} else if (endX - beginX <= -150) {
					SwipeLeft ();
				}
			}
		}
		if (showing) {
			int deltaOffset = (int)(-maxOffset*Time.deltaTime/0.3f);
			ALPSSkin.box.overflow.right +=deltaOffset;
			ALPSSkin.button.overflow.right +=deltaOffset;
			ALPSSkin.box.contentOffset = new Vector2(ALPSSkin.box.contentOffset.x+deltaOffset,0);
			ALPSSkin.button.contentOffset = new Vector2(ALPSSkin.button.contentOffset.x+deltaOffset,0);
			if (ALPSSkin.box.overflow.right >= 0) {
				ALPSSkin.box.overflow.right = 0;
				ALPSSkin.button.overflow.right = 0;
					ALPSSkin.box.contentOffset = new Vector2(0,0);
				ALPSSkin.button.contentOffset = new Vector2(0,0);
				showing = false;
			}
			
		} else if (hiding) {
			int deltaOffset = (int)(-maxOffset*Time.deltaTime/0.3f);
			ALPSSkin.box.overflow.right -=deltaOffset;//+= (int) (maxOffset * cumulativeTime);
			ALPSSkin.button.overflow.right -=deltaOffset;
			ALPSSkin.box.contentOffset = new Vector2(ALPSSkin.box.contentOffset.x-deltaOffset,0);
			ALPSSkin.button.contentOffset = new Vector2(ALPSSkin.button.contentOffset.x-deltaOffset,0);
			if (ALPSSkin.box.overflow.right <= maxOffset) {
				ALPSSkin.box.overflow.right = (int)maxOffset-1;
				ALPSSkin.button.overflow.right = (int)maxOffset-1;
				ALPSSkin.box.contentOffset = new Vector2((int) maxOffset-1,0);
				ALPSSkin.button.contentOffset = new Vector2((int) maxOffset-1,0);
				hiding = false;
				GUIVisible = false;
			}
		}
	}

	/// <summary>
	/// Triggered when user swipes right. Shows device selection menu.
	/// </summary>
	private void SwipeRight(){
		if (!GUIVisible) {
			GUIVisible = true;
			showing = true;
		}
	}

	/// <summary>
	/// Triggered when user swipes left. Hides device selection menu.
	/// </summary>
	private void SwipeLeft(){
		if (GUIVisible) {
			hiding = true;
		}
	}

	/// <summary>
	/// Draws device selection menu.
	/// </summary>
	void OnGUI(){
		if (GUIVisible) {

		
			if(GUIMenu){
				GUI.skin = ALPSSkin;
				GUI.Box (new Rect (0, 0, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix), "Menu");
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.15f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.15f), "Choose a device")) {
					GUIDeviceSelection=true;
					GUIMenu=false;
				}
				
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.30f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.15f), "Custom configuration")) {
					GUICustomConfiguration=true;
					GUIMenu=false;
				}
			}
			if(GUIDeviceSelection){
				GUI.skin = ALPSSkin;
				// Make a background box
				GUI.Box (new Rect (0, 0, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix), "Choose a device");

				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.15f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.15f), "Back")) {
					GUIMenu=true;
					GUIDeviceSelection=false;
				}
			
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.30f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.15f), "Default")) {
					controller.SetDevice (Device.DEFAULT);
				}
			
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.45f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.15f), "Altergaze")) {
					controller.SetDevice (Device.ALTERGAZE);
				}
			
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.60f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.15f), "Cardboard")) {
					controller.SetDevice (Device.CARDBOARD);
				}

				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.75f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.15f), "Firefly VR")) {
					controller.SetDevice (Device.FREEFLY_VR);
				}
			}
			if(GUICustomConfiguration){
				GUI.skin = ALPSSkin;
				GUI.Box (new Rect (0, 0, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix), "Custom configuration");
			
				//Back
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.15f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.15f), "Back")) {
					GUIMenu=true;
					GUICustomConfiguration=false;
				}

				//Barrel distortion
				//K1
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.30f, ALPSController.screenWidthPix * 0.175f, ALPSController.screenHeightPix * 0.10f), "Barrel distortion K1 : "+controller.deviceConfig.k1.ToString("F1"))) {
				}
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.40f, ALPSController.screenWidthPix * 0.175f, ALPSController.screenHeightPix * 0.10f), "Less")) {
					controller.AddToK1(-0.1f);
				}
				if (GUI.Button (new Rect (ALPSController.screenWidthPix * 0.125f, ALPSController.screenHeightPix * 0.40f, ALPSController.screenWidthPix * 0.125f, ALPSController.screenHeightPix * 0.10f), "More")) {
					controller.AddToK1(0.1f);
				}

				//K2
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.50f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.10f), "Barrel distortion K2 : "+controller.deviceConfig.k2.ToString("F1"))) {
				}
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.60f, ALPSController.screenWidthPix * 0.125f, ALPSController.screenHeightPix * 0.10f), "Less")) {
					controller.AddToK2(-0.1f);
				}
				if (GUI.Button (new Rect (ALPSController.screenWidthPix * 0.125f, ALPSController.screenHeightPix * 0.60f, ALPSController.screenWidthPix * 0.125f, ALPSController.screenHeightPix * 0.10f), "More")) {
					controller.AddToK2(0.1f);
				}

				//CC
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.70f, ALPSController.screenWidthPix * 0.25f, ALPSController.screenHeightPix * 0.10f), "Chromatic correction : "+controller.deviceConfig.chromaticCorrection.ToString("F1"))) {
				}
				if (GUI.Button (new Rect (0, ALPSController.screenHeightPix * 0.80f, ALPSController.screenWidthPix * 0.125f, ALPSController.screenHeightPix * 0.10f), "Less")) {
					controller.AddToChromaticCorrection(-0.1f);
				}
				if (GUI.Button (new Rect (ALPSController.screenWidthPix * 0.125f, ALPSController.screenHeightPix * 0.80f, ALPSController.screenWidthPix * 0.125f, ALPSController.screenHeightPix * 0.10f), "More")) {
					controller.AddToChromaticCorrection(0.1f);
				}
			}
		}
	}
}
