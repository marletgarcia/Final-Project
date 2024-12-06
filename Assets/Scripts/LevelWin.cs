using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    public GameObject WinMenu;
    public Text Teller;
    public AudioSource LevelCompleteAud;

    private int currentLevel;

    void Start()
    {
        // Automatically set the current level based on the active scene
        string sceneName = SceneManager.GetActiveScene().name;

        // Assuming level names are in the format "Level X"
        if (sceneName.StartsWith("Level "))
        {
            currentLevel = int.Parse(sceneName.Substring(6));
        }
        else
        {
            currentLevel = 1; // Default to level 1 if the scene name is not formatted correctly
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelCompleteAud.Play();
            WinMenu.SetActive(true);
        }
    }

    public void NextLvl()
    {
        int nextLevel = currentLevel + 1;
        string nextSceneName = "Level " + nextLevel;

        // Check if the next level exists
        if (Application.CanStreamedLevelBeLoaded(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Next level not found: " + nextSceneName);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveInSlot(int slot)
    {
        PlayerPrefs.SetInt("LevelsClearedInSlot" + slot, currentLevel);
        PlayerPrefs.Save();
        Teller.text = "Saved Progress In Save Slot " + slot;
    }
}
