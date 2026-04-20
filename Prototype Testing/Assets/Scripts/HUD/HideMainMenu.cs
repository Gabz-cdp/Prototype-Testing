using UnityEngine;

public class HideMainMenu : MonoBehaviour
{
    public GameObject MainMenuButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuButtonClicked()
    {
        if (MainMenuButton.activeInHierarchy == true) //MainMenuButton is visible
            MainMenuButton.SetActive(false);
        else
            MainMenuButton.SetActive(true);
    }
}
