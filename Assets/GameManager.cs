using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public enum Stages { Stage1, Stage2, Stage3, Stage4, Stage5 }
    public Stages stage;

    public PlayerController playerController;
    public Slider SustainSlider;

    public List<Sprite> StagesSprites;
    public int currentStage;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<GameManager>();
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        stage = Stages.Stage1;
        DontDestroyOnLoad(gameObject);
        var spriteRenderer = playerController.GetComponent<SpriteRenderer>();

        switch (currentStage)
        {
            case 0:
                spriteRenderer.sprite = StagesSprites[0];
                break;
            case 1:
                spriteRenderer.sprite = StagesSprites[1];
                break;
            case 2:
                spriteRenderer.sprite = StagesSprites[2];
                break;
            case 3:
                spriteRenderer.sprite = StagesSprites[3];
                break;
            case 4:
                spriteRenderer.sprite = StagesSprites[4];
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        switch (stage)
        {
            case Stages.Stage1:
                Stage1();
                break;
            case Stages.Stage2:
                Stage2();
                break;
            case Stages.Stage3:

                break;
            case Stages.Stage4:

                break;
            case Stages.Stage5:

                break;
            default:
                break;
        }
    }

    public void ReloadScene() { 
        SceneManager.LoadScene(System.Enum.GetName(typeof(Stages), stage));
    }

    public void Stage1()
    {
        if (SustainSlider.value >= SustainSlider.maxValue)
        {
            stage = Stages.Stage2;
            SceneManager.LoadScene("Stage2");
        }
    }

    public void Stage2()
    {
        playerController.Movement = PlayerController.MovementType.Sliding;
        stage = Stages.Stage2;


        if (SustainSlider.value >= SustainSlider.maxValue)
        {
            currentStage++;
            SustainSlider.value = 0;

            var spriteRenderer = playerController.GetComponent<SpriteRenderer>();
            switch (currentStage)
            {
                case 0:
                    spriteRenderer.sprite = StagesSprites[0];
                    break;
                case 1:
                    spriteRenderer.sprite = StagesSprites[1];
                    break;
                case 2:
                    spriteRenderer.sprite = StagesSprites[2];
                    break;
                case 3:
                    spriteRenderer.sprite = StagesSprites[3];
                    break;
                case 4:
                    spriteRenderer.sprite = StagesSprites[4];
                    break;
                default:
                    spriteRenderer.sprite = StagesSprites[4];
                    break;
            }
        }
    }



}
