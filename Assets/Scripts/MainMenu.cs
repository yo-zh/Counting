using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [Header("Settings")]
    [SerializeField] private Button soundButton;
    [SerializeField] private Button difficultyButton;

    [Header("Sound")]
    [SerializeField] private Slider effectsSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Button soundBack;

    [Header("Difficulty")]
    [SerializeField] private Toggle easyToggle;
    [SerializeField] private Toggle mediumToggle;
    [SerializeField] private Toggle hardToggle;
    [SerializeField] private Button difficultyBack;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
