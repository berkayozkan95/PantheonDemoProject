using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : Singleton<GameManager>
{
    public Collider finishLine;
    public float ActivationDelay;
    [SerializeField] private Collider[] boundsColliders;
    private CameraPanManager camManager;
    private List<PlayerControllerBase> allPlayers;
    private PlayerControllerBase player;
    private Paintable paintableWall;
    public event EventHandler<OnPlayerFinishedEventArgs> OnPlayerFinished;  

    public class OnPlayerFinishedEventArgs : EventArgs{
        public float activationDelay;
    }

    private void Awake() {
#if UNITY_STANDALONE
         Screen.SetResolution(564, 960, false);
         Screen.fullScreen = false;
#endif
    }

    private void Start() {    
        camManager = FindObjectOfType<CameraPanManager>();
        finishLine = FindObjectOfType<FinishLine>().GetComponent<Collider>();
        PlayerControllerBase[] _allPlayers = FindObjectsOfType<PlayerControllerBase>();
        player = FindObjectOfType<PlayerController>();
        allPlayers = _allPlayers.ToList<PlayerControllerBase>();
        paintableWall = FindObjectOfType<Paintable>();
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

    private int sortFunc(PlayerControllerBase a, PlayerControllerBase b){
        if(a.HasFinished || b.HasFinished) return 0;
        if(a.DistanceToFinish > b.DistanceToFinish) return 1;
        else if(a.DistanceToFinish < b.DistanceToFinish) return -1; 
        return 0;
    }

    public (int, int) SortPlayerRanking(){
        allPlayers.Sort(sortFunc);
        int playerIndex = 0;
        int totalPlayers = allPlayers.Count;
        for (int i = 0; i < allPlayers.Count; i++)
        {
             if(allPlayers[i] == player){
                playerIndex = i + 1;
            }
        }
        return (playerIndex, totalPlayers);
    }

    public int GetPercentagePainted(){
        return paintableWall.GetPercentageRed();
    }

    public void PlayerFinished(){
        OnPlayerFinished?.Invoke(this, new OnPlayerFinishedEventArgs { activationDelay = this.ActivationDelay});
    }
}
