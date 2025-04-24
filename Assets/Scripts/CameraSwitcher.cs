using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform gameViewPosition;
    public Transform shopViewPosition;
    public GameObject shopButton;
    public GameObject backButton;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        // Makes sure Back button is hidden at start
        backButton.SetActive(false);
        shopButton.SetActive(true);
    }

    public void GoToShop()
    {
        cam.transform.position = shopViewPosition.position;
        shopButton.SetActive(false);
        backButton.SetActive(true);

        GameManager.shopIsOpen = true;
        Time.timeScale = 0f;
    }

    public void GoToGame()
    {
        cam.transform.position = gameViewPosition.position;
        shopButton.SetActive(true);
        backButton.SetActive(false);

        GameManager.shopIsOpen = false;
        Time.timeScale = 1f;
    }


}


