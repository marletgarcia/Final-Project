using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManger : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider SoundEffectsSlider;
    public AudioSource BGM;
    public GameObject SaveSlotsMenu;
    public GameObject SaveSlot1;
    public GameObject SaveSlot2;
    public GameObject SaveSlot3;

    void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("IsFirstTimeOpened") == 0)
        {
            PlayerPrefs.SetInt("IsFirstTimeOpened", 1);
            PlayerPrefs.SetFloat("BGMVol", 1f);
            PlayerPrefs.SetFloat("SFXVol", 1f);
        }

        BGMSlider.value = PlayerPrefs.GetFloat("BGMVol");
        SoundEffectsSlider.value = PlayerPrefs.GetFloat("SFXVol");
        BGM.volume = BGMSlider.value;
    }

    public void DoneOptions()
    {
        PlayerPrefs.SetFloat("BGMVol", BGMSlider.value);
        PlayerPrefs.SetFloat("SFXVol", SoundEffectsSlider.value);
        BGM.volume = BGMSlider.value;
    }

    public void Quit()
    {
        Application.Quit(); 
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadFromSaveSlot(int slot)
    {
        int levelToLoad = PlayerPrefs.GetInt("LevelsClearedInSlot" + slot) + 1;
        SceneManager.LoadScene("Level " + levelToLoad);
    }

    public void PlayBtnPressed()
    {
        if(PlayerPrefs.GetInt("LevelsClearedInSlot1") == 0 || PlayerPrefs.GetInt("LevelsClearedInSlot2") == 0 || PlayerPrefs.GetInt("LevelsClearedInSlot3") == 0)
        {
            SaveSlotsMenu.SetActive(true);
            Debug.Log(PlayerPrefs.GetInt("LevelsClearedInSlot1"));
            if(PlayerPrefs.GetInt("LevelsClearedInSlot1") != 0)
            {
                SaveSlot1.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("LevelsClearedInSlot2") != 0)
            {
                SaveSlot2.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("LevelsClearedInSlot3") != 0)
            {
                SaveSlot3.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            LoadNewGame();
        }
    }
}
