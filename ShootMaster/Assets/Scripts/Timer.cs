using UnityEngine;

public class Timer : MonoBehaviour
{
    public int duration = 60;
    public int timeRemaining;
    public bool isCountingDown = false;

    public void Begin()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
    }

    public void Stop()
    {
        isCountingDown = false;

    }

    private void _tick()
    {
        if(isCountingDown)
        {
            timeRemaining--;
            if (timeRemaining > 0)
            {
                Invoke("_tick", 1f);
            }
            else
            {
                isCountingDown = false;
                Debug.Log("end timer");
            }
        }
    }

    
}
