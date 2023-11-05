using UnityEngine;

public class GameController : MonoBehaviour
{
    private FinishHole[] holes;

    private void Awake()
    {
        holes = FindObjectsOfType<FinishHole>();
        Debug.Log("Holes found: " + holes.Length);

        foreach (var hole in holes)
        {
            hole.BallWentInHoleEvent += FinishedHole;
        }
    }

    private void OnDestroy()
    {
        foreach (var hole in holes)
        {
            hole.BallWentInHoleEvent -= FinishedHole;
        }
    }

    private void FinishedHole(int holeNumber)
    {
        Debug.Log("A ball went in a hole #" + holeNumber);
    }
}
