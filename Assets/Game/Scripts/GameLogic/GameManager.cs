using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    public Collider finishLine;
    [SerializeField] private Collider[] boundsColliders;
    [SerializeField] private List<PlayerControllerBase> allPlayers;
    [SerializeField] private PlayerControllerBase player;
    // Update is called once per frame
    
    private void Start() {
        finishLine = FindObjectOfType<FinishLine>().GetComponent<Collider>();
        PlayerControllerBase[] _allPlayers = FindObjectsOfType<PlayerControllerBase>();
        player = FindObjectOfType<PlayerController>();
        allPlayers = _allPlayers.ToList<PlayerControllerBase>();
    }

    private void LateUpdate() 
    {
        foreach (var item in boundsColliders)
        {
            Bounds bounds = item.bounds;
            AstarPath.active.UpdateGraphs(bounds);  
        }   
        SortPlayerRanking();   
    }

    public (int, int) SortPlayerRanking(){
        allPlayers = allPlayers.OrderBy(x=>x.DistanceToFinish).ToList();
        int playerIndex = 0;
        int totalPlayers = allPlayers.Count;
        for (int i = 0; i < allPlayers.Count; i++)
        {
             if(allPlayers[i] == player){
                playerIndex = i + 1;
                Debug.Log("Player is in" + (i + 1) + "th place");
            }
        }
        return (playerIndex, totalPlayers);
    }
}
