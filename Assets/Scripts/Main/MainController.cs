using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject xText;
    public Transform player;
    public PlayerController playerController;
    public AllyController allyController;
    public PlatformManager platformManager;

    public TextMeshProUGUI roomsText;
    public int ghoulsKilled=0;
    public TextMeshProUGUI ghoulsText;

    public Animator deathAnimator;

    public void Die()
    {
        deathScreen.SetActive(true);
        deathAnimator.SetTrigger("DeathUI");
        xText.SetActive(false);

        roomsText.text=platformManager.checkPointsPassed+"";
        ghoulsText.text=ghoulsKilled+"";
    }   

    public void Restart()
    {
        /*deathScreen.SetActive(false);
        xText.SetActive(true);
        player.position=Vector3.zero;
        playerController.enabled = true;
        platformManager.Restart();*/
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
