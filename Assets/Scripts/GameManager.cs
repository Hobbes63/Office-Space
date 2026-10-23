using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    /*To Do List: 
    Needs to control how time will scale in game (not just literal run-time, but also in game time and how it's represented)
        -Need to establish the real time to game time ratio (i.e. 5 seconds equates to 5 minutes in game?)

    Needs to evaluate how difficulty scaling/enemy scaling will work since we have fixed(?) time chunks

    Needs to control item spawn rate, item spawn conditions...

    Needs to control flags for tasks/task completion, available task list, and reward/reward scaling for those tasks.
    */

    int waveCount;
    int roundCount;

    float runTimer; //Shows true run-time of player run
    float dayTimer; //Shows simulated time for in-game clock

    int taskCount; //Can be updated/increased with later waves

    int playerMoneyCount;
    

    public List<KeyValuePair<string, string>> Tasks;

    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void GiveTask()
    {
        
    }
}
