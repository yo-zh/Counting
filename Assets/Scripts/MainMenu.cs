using Unity.VisualScripting;
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
    [SerializeField] private GameObject settings;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button difficultyButton;
    [SerializeField] private Button settingsBack;

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
        Time.timeScale = 0.0f; // put into game manager

        startButton.onClick.AddListener(StartGame);

        settingsButton.onClick.AddListener(delegate { ToggleSettings(true); });
        settingsBack.onClick.AddListener(delegate { ToggleSettings(false); });

        quitButton.onClick.AddListener(() => { Application.Quit(); Debug.Log("Quitting"); });

        effectsSlider.onValueChanged.AddListener(delegate { AdjustVolume(effectsSlider, effectsSlider.value); });
        musicSlider.onValueChanged.AddListener(delegate { AdjustVolume(musicSlider, musicSlider.value); });

        easyToggle.onValueChanged.AddListener(delegate { ToggleDifficulty(easyToggle, easyToggle.isOn); });
        mediumToggle.onValueChanged.AddListener(delegate { ToggleDifficulty(mediumToggle, mediumToggle.isOn); });
        hardToggle.onValueChanged.AddListener(delegate { ToggleDifficulty(hardToggle, hardToggle.isOn); });
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f; // put into game manager
        settingsButton.transform.parent.gameObject.SetActive(false);
    }

    private void ToggleSettings(bool value)
    {
        settingsButton.transform.parent.gameObject.SetActive(!value);
        settings.SetActive(value);
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

    private void ToggleDifficulty(Toggle activeToggle, bool value)
    {
        // rewrite, looks like shit
        switch (activeToggle.name, value)
        {
            case ("EasyToggle", true):
                mediumToggle.isOn = false;
                hardToggle.isOn = false;
                easyToggle.interactable = false;
                mediumToggle.interactable = true;
                hardToggle.interactable = true;
                break;
            case ("MediumToggle", true):
                easyToggle.isOn = false;
                hardToggle.isOn = false;
                easyToggle.interactable = true;
                mediumToggle.interactable = false;
                hardToggle.interactable = true;
                break;
            case ("HardToggle", true):
                easyToggle.isOn = false;
                mediumToggle.isOn = false;
                easyToggle.interactable = true;
                mediumToggle.interactable = true;
                hardToggle.interactable = false;
                break;
        }
    }
}
