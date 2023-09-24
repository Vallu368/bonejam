using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PlayButton : MonoBehaviour
{
    public Camera startingCamera;
    public Camera playerCamera;
    public PlayerController playerController;
    public Animation playerAnimation;
    public Animator playerAnimator;
    public float transitionDuration = 2f;

    private float transitionStartTime;
    private bool isTransitioning = false;

    private Button playButton;

    private void Start()
    {
        playButton = GetComponent<Button>(); 

        if (startingCamera == null || playerCamera == null || playerController == null)
        {
            Debug.LogError("Camera or player controller references not set.");
            enabled = false;
            return;
        }

        playerCamera.gameObject.SetActive(false);
        playerController.EnableControls(false);

        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void Update()
    {
        if (isTransitioning)
        {
            float transitionProgress = (Time.time - transitionStartTime) / transitionDuration;
            transitionProgress = Mathf.Clamp01(transitionProgress); 

            Vector3 startingCameraPosition = startingCamera.transform.position;
            Vector3 playerCameraPosition = playerCamera.transform.position;
            Vector3 newPosition = Vector3.Lerp(startingCameraPosition, playerCameraPosition, transitionProgress);

            startingCamera.transform.position = newPosition;

            if (transitionProgress >= 1f)
            {
                isTransitioning = false;

                playerCamera.gameObject.SetActive(true);

                startingCamera.gameObject.SetActive(false);

                Camera.main.gameObject.SetActive(true);

                playerAnimator.SetBool("wakingUp", true);

                StartCoroutine(EnableControlsAfterAnimation());
                //koira animaatio tänne..?
            }
        }
    }

    private IEnumerator EnableControlsAfterAnimation()
    {
        yield return new WaitForSeconds(playerAnimation.clip.length);

        playerAnimator.SetBool("wakingUp", false);

        playerController.EnableControls(true);
    }

    public void OnPlayButtonClick()
    {
        Image img = this.GetComponent<Image>();
        img.enabled = false;
        TextMeshProUGUI txt = this.GetComponentInChildren<TextMeshProUGUI>();
        txt.enabled = false;

        isTransitioning = true;
        transitionStartTime = Time.time;
    }
}
