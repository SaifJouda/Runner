using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public TextMeshPro leftText;
    public TextMeshPro rightText;
    public AllyController allyController;

    public GameObject nextPlatform;
    public EnemyManager enemyManager;
    public PowerUpCollider powerUpCollider;


    private PowerUp leftPower;
    private PowerUp rightPower;

    public enum MathType
    {
        Plus,
        Minus,
        Mult,
        Div
    }

    public void SetNextEnemyManager(EnemyManager nextEnemyManager)
    {   
        powerUpCollider.nextEnemyManager=nextEnemyManager;
    }

    public void SetCheckPoint(AllyController allyControllerN, GameObject nextPlatformN, PlatformManager platformManager, int checkPointsPassed, MainController main)
    {
        allyController=allyControllerN;
        nextPlatform=nextPlatformN;
        powerUpCollider.platformManager=platformManager;
        createPowerUps(checkPointsPassed);
        enemyManager.mainController=main;
        enemyManager.SpawnEnemies(checkPointsPassed);
        if(nextPlatform!=null) 
        {
            nextPlatform.GetComponent<CheckPoint>().SetNextEnemyManager(enemyManager);
        }
    }

    public struct PowerUp
    {
        public MathType mathType;
        public int number;
    }


    public void createPowerUps(int level)
    {
        float intensity=(float)Random.Range(1, 5)+(float)level/10f; // Round Later
        //Debug.Log(intensity+"");
        leftPower = createPowerUp(intensity);
        rightPower = createPowerUp(intensity);
        leftText.text=getPowerString(leftPower);
        rightText.text=getPowerString(rightPower);
    }

    private PowerUp createPowerUp(float intensity)
    {
        PowerUp returnPower = new PowerUp();
        int randomNum = Random.Range(1, 5);
        switch(Random.Range(1, 5))
        {
            case 1:
                returnPower.mathType = MathType.Plus;
                returnPower.number = (int)Random.Range(1f, 8f*intensity);
                break;
            case 2:
                returnPower.mathType = MathType.Minus;
                returnPower.number = (int)Random.Range(1f, 4f*intensity);
                break;
            case 3:
                returnPower.mathType = MathType.Mult;
                returnPower.number = (int)Random.Range(2f, 2f*intensity);
                break;
            case 4:
                returnPower.mathType = MathType.Div;
                returnPower.number = (int)Random.Range(2f, 2f*intensity); // intensity chooses powerup, higher = div and mult
                break;
        }
   
    
        return returnPower;
    }

    private string getPowerString(PowerUp powerUp)
    {
        string text = "";
        switch (powerUp.mathType)
        {
            case MathType.Plus:
                text= "+";
                break;
            case MathType.Minus:
                text= "-";
                break;
            case MathType.Mult:
                text= "x";
                break;
            case MathType.Div:
                text= "/";
                break;
        }
        return ""+text+powerUp.number;
    }

    public void LeftPowerUp()
    {
        ChangeX(leftPower);
    }

    public void RightPowerUp()
    {
        ChangeX(rightPower);
    }

    private void ChangeX(PowerUp powerUp)
    {
        int x = allyController.getX();
        switch (powerUp.mathType)
        {
            case MathType.Plus:
                allyController.PickUp(x+powerUp.number);
                break;
            case MathType.Minus:
                allyController.PickUp(x-powerUp.number);
                break;
            case MathType.Mult:
                allyController.PickUp(x*powerUp.number);
                break;
            case MathType.Div:
                allyController.PickUp((int)(x/powerUp.number));
                break;
        }
    }
}
