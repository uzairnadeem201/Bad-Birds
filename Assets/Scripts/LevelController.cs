using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Monster[] monsters;
    [SerializeField] string nextLevel;
    private void OnEnable()
    {
        monsters = FindObjectsOfType<Monster>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(monstersAllDead())
        {
            goToNextLevel();
        }
        
    }

    private void goToNextLevel()
    {
        Debug.Log("go to next level" + nextLevel);
        SceneManager.LoadScene(nextLevel);
    }

    private bool monstersAllDead()
    {
        foreach (Monster monster in monsters)
        {
            if ((monster.gameObject.activeSelf))
            {
                return false;
            }
           
        }
        return true;
    }
}
