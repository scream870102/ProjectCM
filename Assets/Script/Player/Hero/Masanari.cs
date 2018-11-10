﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
//class for hero masanari
//this class inherit from IPlayer
public class Masanari : IPlayer {
	//set hero type
	//get hero property from Gamemanger instance attribution
	//get rigidbody and set its mass
	public override void Start ( ) {
		Hero = EHero.MASANARI;
		Props = GameManager.instance.attribution.allHeroProps [(int) EHero.MASANARI];
		base.Start ( );
		rb = GetComponent<Rigidbody2D> ( );
		rb.mass = Props.mass;
	}
}
