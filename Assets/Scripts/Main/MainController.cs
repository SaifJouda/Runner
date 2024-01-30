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

    public TextNumber roomsText;
    public int ghoulsKilled=0;
    public TextNumber ghoulsText;

    public Animator deathAnimator;

    public Animator blackscreenAnimator;

    void Start()
    {

    }

    public void Die()
    {
        deathScreen.SetActive(true);
        deathAnimator.SetTrigger("DeathUI");
        xText.SetActive(false);

        roomsText.finalNumber=platformManager.checkPointsPassed;
        ghoulsText.finalNumber=ghoulsKilled;
    }   

    public void Restart()
    {
        blackscreenAnimator.SetTrigger("fadeOut");
        /*deathScreen.SetActive(false);
        xText.SetActive(true);
        player.position=Vector3.zero;
        playerController.enabled = true;
        platformManager.Restart();*/
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
    }
}
