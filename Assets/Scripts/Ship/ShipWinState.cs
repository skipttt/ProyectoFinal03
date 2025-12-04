using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este codigo va en la nave
// Se asigna la camara y el player
// Cambiar Nombre de la Escena
public class ShipWinState : MonoBehaviour
{
    public GameObject portalPrefab;
    public Transform portalSpawnPoint;
    public Transform floatShip;

    private bool sequenceStarted = false;

    public Camera cinematicCamera;
    public GameObject player;

    public string sceneName = "InBetweenScene";

    private void OnTriggerEnter(Collider other)
    {
        GemManagerPlayer gemManager = other.GetComponent<GemManagerPlayer>();
        if (gemManager == null)
        {
            Debug.Log("El jugador no tiene GemManagerPlayer.");
            return;
        }
        if (!gemManager.goalAchieved)
        {
            Debug.Log("El jugador aún no ha conseguido todos los coleccionables.");
            return;
        }
        if (sequenceStarted)
        {
            Debug.Log("Secuencia En Proceso");
            return;
        }
        sequenceStarted = true;
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {

        // Activar animación de la nave
        float t = 0;
        Vector3 start = transform.position;
        Vector3 end = floatShip.position;

        player.SetActive(false);
        cinematicCamera.gameObject.SetActive(true);

        while (t < 0.2)
        {
            t += Time.deltaTime / 2f;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }


        // Crear portal
        GameObject portal = Instantiate(portalPrefab, portalSpawnPoint.position, portalSpawnPoint.rotation);


        yield return new WaitForSeconds(0.4f);

        // Mover nave hacia el portal (si no tienes animación completa)
        t = 0;
        start = transform.position;
        end = portalSpawnPoint.position;

        Vector3 startScale = transform.localScale;
        Vector3 endScale = new Vector3(0.3f,0.3f,0.3f);

        while (t < 0.7)
        {
            t += Time.deltaTime / 2f;
            transform.position = Vector3.Lerp(start, end, t);
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }

        // Cambio de escena
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
