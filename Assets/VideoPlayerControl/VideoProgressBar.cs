using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoProgressBar : MonoBehaviour//, IDragHandler, IPointerDownHandler
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private Image progress;
    [SerializeField]
    private GameObject Question;
    bool buttonSelected = false;
    [SerializeField]
    Button playBtn;
    bool looped = false;
    bool ButtonLooped = false;
    private void Update()
    {
        if (videoPlayer.time < 1 && looped)
        {
            videoPlayer.Pause();
            looped = false;
            ButtonLooped = false;
            buttonSelected = false;
        }
        if (videoPlayer.frameCount > 0)
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;

        if (videoPlayer.time > 24.14f && videoPlayer.time < 40f)
        {
            Question.SetActive(true);
        }
        else
        {
                Question.SetActive(false);
        }
        if (videoPlayer.time == 40f)
        {
            looped = true;
            checkbuttonselected();
        }

    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    TrySkip(eventData);
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    TrySkip(eventData);
    //}

    //private void TrySkip(PointerEventData eventData)
    //{
    //    Vector2 localPoint;
    //    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
    //        progress.rectTransform, eventData.position, null, out localPoint))
    //    {
    //        float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
    //        SkipToPercent(pct);
    //    }
    //}
    public void SkipToEnd(string button)
    {
        videoPlayer.time = 40f;
        Question.SetActive(false);
        print(button+" was selected!");
        buttonSelected = true;
    }
    private void checkbuttonselected()
    {
        if (!buttonSelected && !ButtonLooped)
        {
            print("Nothing was Selected!");
            ButtonLooped = true;
        }
    }
}