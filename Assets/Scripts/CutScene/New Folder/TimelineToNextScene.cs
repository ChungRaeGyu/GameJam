using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineToNextScene : MonoBehaviour
{
    public PlayableDirector director;     // 타임라인 연결
    public string nextSceneName;          // 넘어갈 씬 이름

    void Start()
    {
        // 타임라인 끝났을 때 호출될 함수 등록
        if (director != null)
            director.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector pd)
    {
        // 끝난 타임라인이 내가 등록한 그 타임라인이면
        if (pd == director)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
