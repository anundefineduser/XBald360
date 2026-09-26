using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class VideoPlayerScript : MonoBehaviour {
    [SerializeField]
    private string videoPath;

    [SerializeField]
    private Text textTest;

    private string fullPath;

    private void Start()
    {
        // X360VideoPlayer.SetFullscreen();
        X360VideoPlayer.SetRectangle(0,0,602,572);
        fullPath = Path.Combine("game:\\Media\\Raw", videoPath);
        textTest.alignment = TextAnchor.MiddleCenter;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            print(textTest.alignment);
            textTest.alignment = TextAnchor.MiddleCenter;
            print(textTest.alignment);
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (X360VideoPlayer.IsPlaying()) return;
            print(X360VideoPlayer.Play(fullPath, false));
        }
    }
}
