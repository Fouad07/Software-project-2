using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocationState
{
    Disabled,
    TimedOut,
    Failed,
    Enabled
}
public class GPSManager : MonoBehaviour {

    public static int SCREEN_DENSITY;
    private GUIStyle debugStyle;
    //Approximate radius of the earth (in kilometers)
    const float EARTH_RADIUS = 6371;
    private LocationState state;
    //Position on earth (in degrees)
    private float latitude;
    private float longitude;
    //Distance walked (in meters)
    private float distance;
    //Coins obtained (1 for every 100 meters walked)
    private int coins;

	// Use this for initialization
	IEnumerator Start () {
		if(Screen.dpi > 0f)
        {
            SCREEN_DENSITY = (int)(Screen.dpi / 160f);
        }
        else
        {
            SCREEN_DENSITY = (int)(Screen.currentResolution.height / 600);
        }

        debugStyle = new GUIStyle();
        debugStyle.fontSize = 16 * SCREEN_DENSITY;
        debugStyle.normal.textColor = Color.white;

        state = LocationState.Disabled;
        latitude = 0f;
        longitude = 0f;
        distance = 0f;
        coins = 0;
        if(Input.location.isEnabledByUser)
        {
            Input.location.Start();
            int waitTime = 15;
            while(Input.location.status == LocationServiceStatus.Initializing && waitTime > 0)
            {
                yield return new WaitForSeconds(1);
                waitTime--;
            }

            if(waitTime == 0)
            {
                state = LocationState.TimedOut;
            }
            else if(Input.location.status == LocationServiceStatus.Failed)
            {
                state = LocationState.Failed;
            }
            else
            {
                state = LocationState.Enabled;
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
