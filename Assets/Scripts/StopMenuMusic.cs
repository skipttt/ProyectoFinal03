using UnityEngine;

public class StopMenuMusic : MonoBehaviour
{
    void Awake() // antes de que suene la música
    {
        GameObject music = GameObject.FindWithTag("Music");
        if (music != null)
        {
            Destroy(music);
        }
    }
}
