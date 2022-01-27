using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlacement : MonoBehaviour
{
    private int playerIndex;
    private int totalPlayerCount;
    private Text text;

    private void Start() {
        text = GetComponent<Text>();
    }

    private void Update() {
       (playerIndex, totalPlayerCount) = GameManager.Instance.SortPlayerRanking();
        text.text = playerIndex + "/" + totalPlayerCount;

    }
}
