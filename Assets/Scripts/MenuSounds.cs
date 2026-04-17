using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSound : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerClickHandler, ISubmitHandler
{
    public AudioSource audioSource;

    public AudioClip moveSound;
    public AudioClip clickSound;

    public float soundCooldown = 0.15f;
    private static float lastSoundTime = 0f;
    private static GameObject lastSelected;


    public void OnSelect(BaseEventData eventData)
    {
        if (!MenuState.firstSelectionDone)
        {
            MenuState.firstSelectionDone = true;
            return;
        }

        PlayMoveSound();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayMoveSound();
    }

    void PlayMoveSound()
    {
        if (lastSelected == gameObject)
            return;

        if (Time.unscaledTime - lastSoundTime < soundCooldown)
            return;

        audioSource.PlayOneShot(moveSound);

        lastSelected = gameObject;
        lastSoundTime = Time.unscaledTime;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        audioSource.PlayOneShot(clickSound);
    }
}