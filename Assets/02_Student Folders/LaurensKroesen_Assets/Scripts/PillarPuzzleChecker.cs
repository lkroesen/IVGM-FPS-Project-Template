using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPuzzleChecker : MonoBehaviour
{
    public pillarPuzzle[] pillars = new pillarPuzzle[8];
    public GameObject reward;
    public GameObject one_shot_turret;
    public Transform turret_spawn;
    public bool puzzle_done = false;
    
    public void check()
    {
        int c = 0;
        foreach (var pillarPuzzle in pillars)
        {
            if (pillarPuzzle.active)
                c++;
        }

        if (c == 8)
        {
            puzzle_done = true;
            reward.SetActive(true);
        }
    }

    public float time_passed = 0;
    public float random_number = 10;
    public float penalty_time = 10;

    void nextRandom()
    {
        if (penalty_time > 0)
            penalty_time--;
        
        random_number = (float) (2 * new System.Random().NextDouble()) + penalty_time;
    }
    
    void Start()
    {
        nextRandom();   
    }
    
    // After time passes spawn a turret to spice up the monotomy of the puzzle
    void Update()
    {
        if (puzzle_done) return;
        
        if (time_passed >= random_number)
        {
            // Spawn turret
            Instantiate(one_shot_turret, turret_spawn.position, turret_spawn.rotation);
            nextRandom();
            time_passed = 0;
        }
        time_passed += Time.deltaTime;
    }
}
