using UnityEngine;
using UnityEngine.UI;

public class VitalSignsUI : MonoBehaviour
{
    [SerializeField]  private Text valueText; // Reference to the Text component for displaying the values
    public Canvas uiCanvas;

    private void Start()
    {
        // Hide the value text at the start
        valueText.gameObject.SetActive(false);
        uiCanvas.gameObject.SetActive(false);
    }

    public void OnHeartRateButtonClick()
    {
        // Handle heart rate button click
        float heartRate = GetHeartRate(); // Replace with your own logic to get the heart rate value
        DisplayValue("Heart Rate: " + heartRate);
    }

    public void OnBreathRateButtonClick()
    {
        // Handle breath rate button click
        float breathRate = GetBreathRate(); // Replace with your own logic to get the breath rate value
        DisplayValue("Breath Rate: " + breathRate);
    }

    private void DisplayValue(string value)
    {
        // Show the value text
        valueText.gameObject.SetActive(true);

        // Set the value text to display the provided value
        valueText.text = value;
    }

    private float GetHeartRate()
    {
        // Replace this with your own logic to retrieve the heart rate value
        // For example, you can get it from a sensor or a data source
        return 80.0f;
    }

    private float GetBreathRate()
    {
        // Replace this with your own logic to retrieve the breath rate value
        // For example, you can get it from a sensor or a data source
        return 16.0f;
    }

    public void ShowUI()
    {
        uiCanvas.gameObject.SetActive(true);
    }

    public void HideUI()
    {
        uiCanvas.gameObject.SetActive(false);
    }
}