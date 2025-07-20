using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBall : MonoBehaviour
{
    private int _health; // ��������� ����

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value < 0 || value > 3) // ���������� �������
            {
                Debug.Log("You can`t set that");
            }
            else
                _health = value;
        }
    }

    protected abstract void takeHP();
    protected abstract void increaseScore(); 
}
