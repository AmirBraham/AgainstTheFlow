using UnityEngine;
using System.Collections;

public class AccesorySelector : MonoBehaviour {

	public GameObject[] Accesories;

	// Use this for initialization
	void Start () {

		for(int i=0;i<SceneManagerP.AccesSum;i++){
			if(PlayerPrefs.GetFloat("SelectedAc")==i){
				gameObject.GetComponent<SpriteRenderer>().sprite = Accesories[i].GetComponent<SpriteRenderer>().sprite as Sprite;
			}	
		}

	}

	// Update is called once per frame
	void Update () {
	}
}
