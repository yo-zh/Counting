using UnityEngine;
using UnityEngine.Audio;
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
    [SerializeField] private AudioMixer audioMixer;

    [Header("Difficulty")]
    [SerializeField] private Toggle easyToggle;
    [SerializeField] private Toggle mediumToggle;
    [SerializeField] private Toggle hardToggle;
    [SerializeField] private Button difficultyBack;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        effectsSlider.onValueChanged.AddListener(delegate { AdjustVolume(effectsSlider, effectsSlider.value); });
        musicSlider.onValueChanged.AddListener(delegate { AdjustVolume(musicSlider, musicSlider.value); });
    }

    void Update()
    {
        
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
    }

    private void AdjustVolume(Slider changedSlider, float value)
    {
        if (changedSlider.name == effectsSlider.name)
        {
            audioMixer.SetFloat("EffectsVolume", value);
        }
        else if (changedSlider.name == musicSlider.name)
        {
            audioMixer.SetFloat("MusicVolume", value);
        }
    }
}
