using UnityEngine;

public class PauseableObject : MonoBehaviour
{
    private bool isPaused = false;
    private MonoBehaviour[] scriptsToDisable;
    public GameObject gameCanvas; // Reference to the game canvas.

    private void Start()
    {
        // Get references to all the scripts that you want to disable when paused.
        scriptsToDisable = GetComponentsInChildren<MonoBehaviour>(true); // Include inactive scripts.
    }

    public void Pause()
    {
        // Disable all the scripts when pausing.
        foreach (var script in scriptsToDisable)
        {
            script.enabled = false;
        }

        // Optionally, you can also stop any ongoing coroutines or animations here.

        // Pause the canvas by disabling it.
        if (gameCanvas != null)
        {
            gameCanvas.SetActive(false);
        }

        isPaused = true;
    }

    public void Resume()
    {
        // Enable all the scripts when resuming.
        foreach (var script in scriptsToDisable)
        {
            script.enabled = true;
        }

        // Optionally, you can restart any coroutines or animations here.

        // Resume the canvas by enabling it.
        if (gameCanvas != null)
        {
            gameCanvas.SetActive(true);
        }

        isPaused = false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
