using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public PlayerController playerController;
    public Slider SustainSlider;

    private void Awake()
    {
        playerController.Movement = PlayerController.MovementType.Falling;
    }
}
