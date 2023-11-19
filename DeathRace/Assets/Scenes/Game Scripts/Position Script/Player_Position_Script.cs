using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public partial class Player_Position_Script : MonoBehaviour
{
	public GameObject closestinfrontobject, closestbehindobject;

	//public    bool showgui= true;
	//public	Texture[] positionTextures = new Texture[ElementsSize];
	bool ElementsExpand = true;
	public static int ElementsSize = 1;

	public int raceposition;
	// public Text racePlayerPos;
	int position_x = 0;
	int position_y = 0;
	int position_width = 0;
	int position_height = 0;


	//public	RawImage positionImage;
	bool computercars_ElementsExpand = true;
	public GameObject[] dogsenemy;
	int dogenemeycount;
	public Enemy_Car_Position_Script[] computercars = new Enemy_Car_Position_Script[computercars_ElementsSize];

	public static int computercars_ElementsSize = 1;

	//public GameObject showText;

	public int positionn = 0, currntpos;
	int lastposition = 0;
	public GameObject[] positionobjectarray;
	GameObject closest;
	position_sensor script;
	public int currentlap = 1;
	public int numbergoneback;
	public int numberofpositions = 0;
	public float positionpercenage = 0.0f;
	public static int stop;
	void Awake()
	{
		dogsenemy = GameObject.FindGameObjectsWithTag("Enemy");
		computercars = FindObjectsOfType<Enemy_Car_Position_Script>();
	}

	void Start()
	{
		//showText.SetActive(false);
		currntpos = 0;


		stop = 0;
		if (stop == 0)
		{
			stop = 1;
			var bob = GameObject.FindObjectsOfType(typeof(GameObject));

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
		}
	}


	void Update()
	{
		// print(raceposition);
		for (int i = 0; i < dogsenemy.Length; i++)
		{
			computercars[i] = dogsenemy[i].GetComponent<Enemy_Car_Position_Script>();
		}
		if (positionn + 1 > currntpos)
		{
			// showText.SetActive(false);

			currntpos = positionn;
		}
		else
		{
			//	showText.SetActive(true);
			if (positionn + 1 < currntpos)
			{
				currntpos = positionn;
			}
		}
		//	positionImage.GetComponent<RawImage>().texture= positionTextures[raceposition];
		//    racePlayerPos.text = (raceposition+1).ToString();

		raceposition = 0;
		foreach (Enemy_Car_Position_Script scripts in computercars)
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