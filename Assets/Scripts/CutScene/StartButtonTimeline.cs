using UnityEngine;
using UnityEngine.Playables;

public class StartButtonTimeline : MonoBehaviour
{
    public PlayableDirector cutsceneTimeline;

    public void OnStartButtonPressed()
    {
        if (cutsceneTimeline != null)
        {
            cutsceneTimeline.time = 0; // 항상 처음부터 재생하고 싶으면
            cutsceneTimeline.Play();   // 타임라인 재생
        }
    }
}
