using UnityEngine;
using UnityEngine.Playables;

public class PressAnyKeyToOpenDoor : MonoBehaviour
{
    public GameObject pressAnyKeyUI;      // "아무 키나…" 텍스트
    public PlayableDirector timeline;     // 이 컷신 타임라인
    public Animator doorAnimator;         // 문 애니메이터 (있으면)

    bool waitingForInput = false;

    // 타임라인에서 이 함수를 Signal로 호출
    public void StartWaiting()
    {
        waitingForInput = true;
        if (pressAnyKeyUI != null)
            pressAnyKeyUI.SetActive(true);

        if (timeline != null)
            timeline.Pause();   // 여기서 컷신 멈추기
    }

    void Update()
    {
        if (!waitingForInput)
            return;

        if (Input.anyKeyDown)
        {
            waitingForInput = false;

            if (pressAnyKeyUI != null)
                pressAnyKeyUI.SetActive(false);

            // 문 열기 (애니메이터 쓰는 경우)
            if (doorAnimator != null)
                doorAnimator.SetTrigger("Open");

            // 문 열리는 걸 타임라인으로 연출할 거라면:
            if (timeline != null)
                timeline.Resume();   // 다음 컷으로 이어서 재생
        }
    }
}
