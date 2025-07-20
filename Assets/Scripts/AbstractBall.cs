
using UnityEngine;

public abstract class AbstractBall : MonoBehaviour //ABSTRACTION
{
    private int _health; 

    public int Health // INCAPSULATION
    {
        get
        {
            return _health;
        }
        set
        {
            if (value < 0 || value > 3) 
            {
                Debug.Log("You can`t set that");
            }
            else
                _health = value;
        }
    }

    protected abstract void takeHP(); // POLYMORPHYSM
    protected abstract void increaseScore(); 
}
