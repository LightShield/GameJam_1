using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
	float timeDiff = 0.0f;
	PlayerControls playerScript;

	void Start()
    {
		playerScript = gameObject.GetComponent<PlayerControls>();

	}

	void Update()
	{
		timeDiff += (Time.unscaledDeltaTime - timeDiff) * 0.1f;
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
		GUIStyle style = new GUIStyle();
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 4 / 100;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
		float msec = timeDiff * 1000.0f;
		float fps = 1.0f / timeDiff;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);
		style.alignment = TextAnchor.UpperRight;
		//score
		GUI.Label(rect, "score = " + playerScript.score, style);
	}
}