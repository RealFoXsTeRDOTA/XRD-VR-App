using System;
using UnityEngine;

public class FinishHole : MonoBehaviour
{
    [SerializeField] private int holeNumber;
    public event Action<int> BallWentInHoleEvent;

    private void OnTriggerEnter(Collider other)
    {
        const string golfBallTag = "GolfBall";

        if (!other.CompareTag(golfBallTag))
        {
            return;
        }

        BallWentInHoleEvent?.Invoke(holeNumber);
        Destroy(other.gameObject);
    }
}
