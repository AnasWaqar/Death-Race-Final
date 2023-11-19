using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMovingCars : MonoBehaviour
{
	public Death_AICarController carOne;
	public Death_AICarController carTwo;
	public Death_AICarController carThree;
	public Death_AICarController carFour;
	public Death_AICarController carFive;
	public Death_AICarController carSix;
	public Death_AICarController carSeven;
	public Death_AICarController carEight;
	//public Death_Race_CarControllerV3 playerCar;
	public GameObject playercars;
	public float delay;
	public AudioSource tracksound;
	//public GameObject wrong;
	// Use this for initialization
	void Awake()
	{
		playercars = GameObject.FindGameObjectWithTag("Player");
	}
	void Start()
	{

		StartCoroutine("Delay");
		playercars = GameObject.FindGameObjectWithTag("Player");
		//playercars.GetComponent<RCC_CarControllerV3>().enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		playercars = GameObject.FindGameObjectWithTag("Player");
	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds(delay);
		carOne.enabled = true;
		carTwo.enabled = true;
		carThree.enabled = true;
		carFour.enabled = true;
		carFive.enabled = true;
		//playerCar.enabled = true;
		playercars.GetComponent<Death_Race_CarControllerV3>().enabled = true;

		FindObjectOfType<Play>().playcount = 1;
		FindObjectOfType<Play>().flagTimer = 1;
		tracksound.GetComponent<AudioSource>().enabled = true;
	}

}
