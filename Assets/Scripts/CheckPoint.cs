using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public TextMeshPro leftText;
    public TextMeshPro rightText;
    public AllyController allyController;

    private PowerUp leftPower;
    private PowerUp rightPower;

    public enum MathType
    {
        Plus,
        Minus,
        Mult,
        Div
    }

    public struct PowerUp
    {
        public MathType mathType;
        public int number;
    }


    public void createPowerUps()
    {
        leftPower = createPowerUp(Random.Range(1.0f, 5.0f));
        rightPower = createPowerUp(Random.Range(1.0f, 5.0f));
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
                break;
            case 2:
                returnPower.mathType = MathType.Minus;
                break;
            case 3:
                returnPower.mathType = MathType.Mult;
                break;
            case 4:
                returnPower.mathType = MathType.Div;
                break;
        }
        returnPower.number = (int)Random.Range(5f, 8f*intensity)/randomNum;
    
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
