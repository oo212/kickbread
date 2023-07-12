using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueryRanking : MonoBehaviour
{
    public Text text_myranking;

    public Text text_number1, text_number2, text_number3, text_number4, text_number5;

    Text[] texts = null;

    public delegate void dele_queryRanking(List<RankingData> list, int myRanking);
    public static dele_queryRanking QueryRankingHandler;

    private void Start()
    {
        QueryRankingHandler += OnQueryRanking;
        texts = new Text[] { text_number1, text_number2, text_number3, text_number4, text_number5};
    }

    void OnQueryRanking(List<RankingData> list, int myranking)
    {
	if(text_myranking == null) {
		Debug.LogWarning("text_myranking is null");
	}
	if(text_number1 == null) {
		Debug.LogWarning("text_myranking is null");
	}
	else{
        text_myranking.text = "My Ranking：" + myranking;

        for (int i = 0; i < list.Count; i++)
        {
            int sum = list[i].BurgerBun + list[i].Bagel + list[i].Toast + list[i].Baguette + list[i].Breadstick;
            texts[i].text = list[i].username + "  " + sum ;
        }
	}
	

    }
}
