using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	public AudioSource heartBeating;
	public GameObject OtherPrefab;
	int numOfOthers = 10;
	//bool isGoingRight = true;
	float beatingRate = 1.0f;

	public Image Heart;
	int cupsOfBeer = 0;
	public Text CupsOfBeer;
	public Text TriedTimes;


	int numsOfHeartBeating = 0;
	float beatingRateSeed = 0f;

	public static int triedTimes = 0; 

	public static float widthOfScreen = 960f;
	public static float heightOfScreen = 640f;

	// Use this for initialization
	void Start () {

		/*for (int i = 0; i < numOfOthers; i++)
		{
			GameObject go = Instantiate(OtherPrefab, new Vector3(Random.Range(-200.0f, 200.0f), Random.Range(-150, 150),0), transform.rotation) as GameObject;
			go.transform.parent = GameObject.Find("Canvas").transform;
			go.transform.localPosition = new Vector3(Random.Range(-200.0f, 200.0f), Random.Range(-150, 150),0);
		}*/

		GameObject[] others = GameObject.FindGameObjectsWithTag ("Other");
		for (int i = 0; i < others.Length; i++) {
			others[i].transform.localPosition = new Vector3(Random.Range(-widthOfScreen / 2, widthOfScreen / 2), Random.Range(-heightOfScreen / 2, heightOfScreen / 2),0);
			
		}

	}
	
	// Update is called once per frame
	void Update () {

		CupsOfBeer.text = "*  " + cupsOfBeer.ToString ();
		TriedTimes.text = "You've tried " + triedTimes + " times";
		beatingRate = (GameObject.Find ("The One").transform.localPosition.x + widthOfScreen / 2) * 0.01f;
	

		InvokeRepeating("HeartBeating", beatingRate, 1);
		if (beatingRate < cupsOfBeer * 0.1f) {
			beatingRate = cupsOfBeer * 0.1f;	
		}

		GameObject[] others = GameObject.FindGameObjectsWithTag ("Other");


			for (int i = 0; i < others.Length; i++) {
						if (others [i].GetComponent<Others> ().IsFacingRight)
			{
								others [i].transform.Translate (new Vector3 (others [i].GetComponent<Others> ().Speed, 0, 0));
				others [i].transform.localScale = new Vector3 (-1, 1, 1);
						
			}	
				else 
			{
				others[i].transform.Translate (new Vector3 (-others[i].GetComponent<Others>().Speed, 0, 0));
				others [i].transform.localScale = new Vector3 (1, 1, 1);
			}
					
			}
	}

	void HeartBeating ()
	{
		//Debug.Log("Heart Beat!");
		//Debug.Log (beatingRate);
		numsOfHeartBeating++;
		heartBeating.Play ();
		if (numsOfHeartBeating % 2 == 1)
			
		{
			
			Heart.rectTransform.localScale = new Vector3 (1.2f, 1.2f, 1);
			
		}
		
		else
			
			Heart.rectTransform.localScale = new Vector3 (1, 1, 1);
	

		CancelInvoke ();
		
	}

	public void OnDrink ()
	{
		//Debug.Log("Drink");
		cupsOfBeer++;
	}


}
