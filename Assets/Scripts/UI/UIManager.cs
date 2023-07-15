using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private List<GameObject> _uiPanels;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        MainMenu();
    }

    public void MainMenu()
    {
        BlockPanel("MenuPanel");
        AudioManager.Instance.PlayMenuMusic();
    }

    public void Options()
    {
        BlockPanel("OptionsPanel");
    }
    public void Instructions()
    {
        BlockPanel("InstructionsPanel");
    }

    public void Credits()
    {
        BlockPanel("CreditsPanel");
        AudioManager.Instance.PlayCreditsMusic();
    }

    public void Gameplay()
    {
        BlockPanel("GameplayPanel");
    }

    public void Pause()
    {
        BlockPanel("PausePanel");
    }

    public void Finish()
    {
        BlockPanel("LosePanel");
    }

    private void BlockPanel(string panelName)
    {
        foreach (GameObject panel in _uiPanels)
        {
            if (panel.name == panelName)
                panel.SetActive(true);
            else
                panel.SetActive(false);
        }
    }

    public void UpdateScoreText(int value)
    {
        _scoreText.text = string.Format("{0:0000}", value);
    }
}

