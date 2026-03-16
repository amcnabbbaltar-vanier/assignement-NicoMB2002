using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoalFlag : MonoBehaviour
{
    public int nextLevelIndex = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (GameManager.Instance.HasEnoughScore())
        {
            SceneManager.LoadScene(nextLevelIndex);
            Debug.Log("Level completed");
        }
        else
        {
            Debug.Log("You need more score pickups before finishing the level!");
        }
    }


}
