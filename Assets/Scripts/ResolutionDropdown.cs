using UnityEngine;
using TMPro; // Import TextMesh Pro namespace

public class ResolutionDropdown : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // Reference to the TMP Dropdown UI
    private Resolution[] resolutions;       // Array to hold all available resolutions

    void Start()
    {
        // Get all available resolutions
        resolutions = Screen.resolutions;

        // Clear existing dropdown options
        resolutionDropdown.ClearOptions();

        // Prepare dropdown options based on available resolutions
        var options = new System.Collections.Generic.List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} x {resolutions[i].height} @ {resolutions[i].refreshRate}Hz";
            options.Add(option);

            // Match current resolution with this resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        // Add options to the TMP dropdown
        resolutionDropdown.AddOptions(options);

        // Set the dropdown to the current resolution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Add a listener for dropdown value change
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    // Method to set the resolution based on the dropdown selection
    public void SetResolution(int resolutionIndex)
    {
        Resolution selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreenMode, selectedResolution.refreshRate);
        Debug.Log($"Resolution set to: {selectedResolution.width} x {selectedResolution.height} @ {selectedResolution.refreshRate}Hz");
    }
}
