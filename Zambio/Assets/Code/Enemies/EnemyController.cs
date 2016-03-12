using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    GameControllerSingleton gc;
    NavAgentGoToTransform enemyNav;

	// Use this for initialization
	void Start () {
        gc = GameControllerSingleton.get();
        enemyNav = GetComponent<NavAgentGoToTransform>();
        enemyNav.target = gc.pc.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
