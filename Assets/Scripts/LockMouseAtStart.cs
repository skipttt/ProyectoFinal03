using UnityEngine;

public class LockMouseAtStart : MonoBehaviour
{
    void Start()
    {
        Debug.Log("LockMouseAtStart: mostrando cursor y desbloqueando");
        Cursor.lockState = CursorLockMode.None; // NO bloqueado
        Cursor.visible = true;                  // Mostrar cursor
    }
}
