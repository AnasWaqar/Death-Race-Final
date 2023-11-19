using UnityEngine;
using System.Collections;

[System.Serializable]
public  class Enemy_Car_Position_Script : MonoBehaviour
{
	public bool hasbeenaddedtofinishingposition = false;
	public GameObject closestinfrontobject;
	public GameObject closestbehindobject;
	//	public GameObject[] bob;
	//gui
	//	public Playerdogscript dogScript;
	public static int ElementsSize = 1;
	bool textureEnabled = true;
	//	public GameObject objecttochangetexture;
	//public Material[] positionTextures = new Material[ElementsSize];
	bool ElementsExpand = true;

	// public Text raceposoppo;

	//race position stuff
	public int raceposition = 0;
	public static int othercomputercars_ElementsSize = 1;
	public GameObject playercar;
	public Enemy_Car_Position_Script[] othercomputercars = new Enemy_Car_Position_Script[othercomputercars_ElementsSize];
	bool othercomputercars_ElementsExpand = true;




	//detector stuff
	public int positionn = 0;
	public float positionpercenage = 0.0f;
	int lastposition = 0;
	public GameObject[] positionobjectarray;
	GameObject closest;
	position_sensor script;
	public int currentlap = 1;
	public int numbergoneback = 0;
	public int numberofpositions = 0;
	void Awake()
	{

		//othercomputercars=GameObject.FindGameObjectsWithTag("opponents");
	}
	void Start()
	{
		playercar = GameObject.FindGameObjectWithTag("Player");
		//othercomputercars=
		//	dogScript=playercar.GetComponent<Playerdogscript>();
		var bob = GameObject.FindObjectsOfType(typeof(GameObject));
		//objecttochangetexture.SetActive(true);
		foreach (GameObject tom in bob)
		{
			if (tom.gameObject.name == "PositionSensor")
			{

				GameObject[] santa;
				santa = new GameObject[0];
				santa = positionobjectarray;
				positionobjectarray = new GameObject[(santa.Length + 1)];
				int rudolf = 0;
				foreach (GameObject obj in santa)
				{
					positionobjectarray[rudolf] = santa[rudolf];
					rudolf = rudolf + 1;
				}
				positionobjectarray[(positionobjectarray.Length - 1)] = tom.gameObject;
			}
		}
		//	dogScript=playercar.GetComponent<Playerdogscript>();
	}

	void off()
	{
		//dogScript.patrolspeed=2;
	}

	void Update()
	{


		/*if(dogScript.patrolspeed==1){
			objecttochangetexture.SetActive(true);

			Invoke("off",2.0f);
		}*/

		//raceposition stuff
		raceposition = 0;
		if (othercomputercars.Length > 0)
		{
			foreach (Enemy_Car_Position_Script scripts in othercomputercars)
			{
				if ((scripts.currentlap - scripts.numbergoneback) > (currentlap - numbergoneback))
				{
					raceposition = raceposition + 1;
				}
				else
				{
					if ((scripts.currentlap - scripts.numbergoneback) == (currentlap - numbergoneback))
					{
						if (scripts.positionn > positionn)
						{
							raceposition = raceposition + 1;
						}
						else
						{
							if (scripts.positionn == positionn)
							{
								if (scripts.positionpercenage > positionpercenage)
								{
									raceposition = raceposition + 1;
								}
							}
						}
					}
				}
			}
		}
		var playerscript = playercar.gameObject.GetComponent<Player_Position_Script>();
		if ((playerscript.currentlap - playerscript.numbergoneback) > (currentlap - numbergoneback))
		{
			raceposition = raceposition + 1;
		}
		else
		{
			if ((playerscript.currentlap - playerscript.numbergoneback) == (currentlap - numbergoneback))
			{
				if (playerscript.positionn > positionn)
				{
					raceposition = raceposition + 1;
				}
				else
				{
					if (playerscript.positionn == positionn)
					{
						if (playerscript.positionpercenage > positionpercenage)
						{
							raceposition = raceposition + 1;
						}
					}
				}
			}
		}

		//texture stuff
		if (textureEnabled == false)
		{
			//	objecttochangetexture.gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			//	objecttochangetexture.gameObject.GetComponent<Renderer>().enabled = true;
			//objecttochangetexture.gameObject.GetComponent<Renderer>().material = positionTextures[raceposition];
			// raceposoppo.text= (raceposition + 1).ToString();

		}


		if (closest == null)
		{
		}
		else
		{
			lastposition = positionn;
			script = closest.gameObject.GetComponent<position_sensor>();
			positionn = script.positionnumber;
			if ((lastposition == numberofpositions) && (positionn == 0))
			{
				if (numbergoneback > 0)
				{
					numbergoneback = numbergoneback - 1;
				}
				else
				{
					currentlap = currentlap + 1;
				}
			}
			if ((lastposition == 0) && (positionn == numberofpositions))
			{
				numbergoneback = numbergoneback + 1;
			}
		}

		float nearestDistanceSqr = Mathf.Infinity;

		foreach (GameObject obj in positionobjectarray)
		{
			Vector3 objectPos = obj.transform.position;
			float distanceSqr = (objectPos - transform.position).sqrMagnitude;
			if (distanceSqr < nearestDistanceSqr)
			{
				closest = obj.gameObject;
				nearestDistanceSqr = distanceSqr;
			}
		}

		var closestscript = closest.gameObject.GetComponent<position_sensor>();
		var closestpositionnumber = closestscript.positionnumber;
		int infrontnumber = 0;
		int behindnumber = 0;
		if (closestpositionnumber == numberofpositions)
		{
			infrontnumber = 0;
			behindnumber = closestscript.positionnumber - 1;
		}
		else
		{
			if (closestpositionnumber == 0)
			{
				infrontnumber = 1;
				behindnumber = numberofpositions;
			}
			else
			{
				infrontnumber = closestscript.positionnumber + 1;
				behindnumber = closestscript.positionnumber - 1;
			}
		}
		//find closest between infront objects

		float neearestDistanceSqr = Mathf.Infinity;
		foreach (GameObject obbj in positionobjectarray)
		{
			var posnumberinobbj = obbj.gameObject.GetComponent<position_sensor>().positionnumber;
			if (posnumberinobbj == infrontnumber)
			{
				Vector3 obbjectPos = obbj.transform.position;
				float diistanceSqr = (obbjectPos - transform.position).sqrMagnitude;
				if (diistanceSqr < neearestDistanceSqr)
				{
					closestinfrontobject = obbj.gameObject;
					neearestDistanceSqr = diistanceSqr;
				}
			}
		}
		//find closest between behind objects

		float neeearestDistanceSqr = Mathf.Infinity;
		foreach (GameObject obbbj in positionobjectarray)
		{
			var posnumberinobbbj = obbbj.gameObject.GetComponent<position_sensor>().positionnumber;
			if (posnumberinobbbj == behindnumber)
			{
				Vector3 obbbjectPos = obbbj.transform.position;
				float diiistanceSqr = (obbbjectPos - transform.position).sqrMagnitude;
				if (diiistanceSqr < neeearestDistanceSqr)
				{
					closestbehindobject = obbbj.gameObject;
					neeearestDistanceSqr = diiistanceSqr;
				}
			}
		}


		float distancebetweenposandinfront = Vector3.Distance(closestinfrontobject.transform.position, closestbehindobject.transform.position);
		float distancebetweenposandbehind = Vector3.Distance(closestbehindobject.transform.position, gameObject.transform.position);
		float distancepercentage;
		distancepercentage = distancebetweenposandbehind / distancebetweenposandinfront;
		positionpercenage = distancepercentage * 100;
	}

}