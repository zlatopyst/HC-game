using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject instance;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Buttons.Button2 += Level;
        Level1 = Instantiate(Resources.Load("Level1", typeof(GameObject))) as GameObject;
        
    }

    private void Level()
    {
        if (count == 0)
        {
            Object.Destroy(Level1);
            Level2 = Instantiate(Resources.Load("Level2", typeof(GameObject))) as GameObject;
        }
        if (count == 1)
        {
           Object.Destroy(Level2);
            Level3 = Instantiate(Resources.Load("Level3", typeof(GameObject))) as GameObject;
        }
        count++;
    }
}
