﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
//A class to controll scene
public class SceneController : MonoBehaviour {
	//store current scene name
	private string sceneName;
	//to store IScene to get info for current scene
	[SerializeField]
	private IScene currentScene = null;
	//to detect if scenecontroller get IScene
	private bool bGetScene;
	//determine how game play
	//include essential info
	public PlayState playState;
	//Init first scene
	void Start ( ) {
		bGetScene = false;
		playState = Test ( );
		InitScene ("TitleScene");
	}
	void Update ( ) {
		//if cureentscene not equal to sceneName try to get it
		if (!bGetScene && currentScene == null)
			GetIScene ( );
	}
	//public method to get next scene
	public void SetScene (string sceneName) {
		SceneManager.LoadScene (sceneName);
		this.sceneName = sceneName;
		currentScene = null;
		bGetScene = false;
	}
	//to get IScene and its derived class
	private void GetIScene ( ) {
		if (currentScene == null)
			currentScene = GameObject.Find (sceneName + "Controller").GetComponent<IScene> ( );
		if (currentScene != null && currentScene.name == sceneName)
			bGetScene = true;
	}
	//Init scene
	public void InitScene (string sceneName) {
		this.sceneName = sceneName;
		currentScene = GameObject.Find (this.sceneName + "Controller").GetComponent (sceneName) as IScene;
		currentScene.SceneController = this;
		//test
		//playState = Test ( );
	}

	//for test
	//set playstate
	private PlayState Test ( ) {
		PlayState temp;
		temp.gameMode = EGameMode.SURVIVOR;
		temp.map = EMap.SUNNY_LAND;
		temp.numOfPlayers = 2;
		temp.heroes = new List<EHero> ( );
		temp.heroesColor = new List<EColor> ( );
		temp.heroes.Add (EHero.PIRATE_BEAR);
		temp.heroesColor.Add (EColor.RED);
		temp.heroes.Add (EHero.MASANARI);
		temp.heroesColor.Add (EColor.ORANGE);
		return temp;
	}
}
