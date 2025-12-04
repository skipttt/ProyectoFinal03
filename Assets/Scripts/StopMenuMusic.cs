using UnityEngine;

public class StopMenuMusic : MonoBehaviour
{
    void Start()
    {
        GameObject music = GameObject.FindWithTag("Music");
        if (music != null)
        {
            Destroy(music);
        }
    }
}
