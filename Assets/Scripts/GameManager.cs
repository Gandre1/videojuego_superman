using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CloudSpawner spawner;
    public Transform player;
    public Transform cameraTransform;
    public CameraFollow cameraFollow;
    public Animator playerAnimator;
    public float startGameY = 8f;
    public float idleDuration = 2f;
    public bool IsGameplay()
    {
        return currentState == GameState.Gameplay;
    }    private float timer = 0f;
    private float initialOffsetY;

    enum GameState
    {
        Idle,
        Intro,
        Gameplay
    }

    private GameState currentState = GameState.Idle;

    void Start()
    {
        initialOffsetY = player.position.y - cameraTransform.position.y;

        player.GetComponent<PlayerMovement>().enabled = false;

        cameraFollow.enabled = false;
        cameraFollow.introMode = false;

        Vector3 pos = cameraTransform.position;
        pos.y = player.position.y - initialOffsetY;
        cameraTransform.position = pos;

        spawner.enabled = false;
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.Idle:
                timer += Time.deltaTime;

                if (timer >= idleDuration)
                {
                    StartIntro();
                }
                break;

            case GameState.Intro:
                IntroSequence();

                if (cameraTransform.position.y >= startGameY)
                {
                    StartGame();
                }
                break;
        }
    }

    void IntroSequence()
    {
        player.position = new Vector3(
            player.position.x,
            cameraTransform.position.y + initialOffsetY,
            player.position.z
        );
    }

    void StartIntro()
    {
        currentState = GameState.Intro;
        cameraFollow.enabled = true;
        cameraFollow.introMode = true;
        playerAnimator.Play("FlyStart");
    }
    void StartGame()
    {
        currentState = GameState.Gameplay;
        cameraFollow.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        playerAnimator.Play("FlyLoop");
        spawner.enabled = true;
        ScoreManager.instance.StartCounting();
        foreach (SkyScroller s in FindObjectsByType<SkyScroller>(FindObjectsSortMode.None))
        {
            s.Activate();
        }
    }
    
}