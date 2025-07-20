using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRelay : AbstractBall
{
    public SpawnManager spawnManagerScript;
    protected override void increaseScore()
    {
        spawnManagerScript.score += 5;
    }
    protected override void takeHP()
    {
        spawnManagerScript.Health -= 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            increaseScore();
        }
        else if (other.CompareTag("Red"))
        {
            takeHP();
        }
    }

}
