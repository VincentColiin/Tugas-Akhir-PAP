using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    private int state = 1;
    // Start is called before the first frame update
    public void onCollision()
    {
        gameObject.SetActive(true);
        updateState();
    }

    public int getState()
    {
        return state;
    }

    public void updateState()
    {
        state = 0;
    }

}
