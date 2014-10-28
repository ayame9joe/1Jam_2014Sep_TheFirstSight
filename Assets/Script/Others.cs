using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Others: MonoBehaviour{

	private bool isFacingRight;
	private float speed;

	private bool spaceDown = false;

	public static int othersCount = 0;
	public bool IsFacingRight
	{
		get
		{
			//Some other code
			return isFacingRight;
		}
		set
		{
			//Some other code
			isFacingRight = value;
		}
	}

	public float Speed
	{
		get
		{
			//Some other code
			return speed;
		}
		set
		{
			//Some other code
			speed = value;
		}
	}

	public void Start ()
	{
		if (this.name != "The Line" && this.name != "The One") {
		
			othersCount++;
		//	Debug.Log(othersCount);

			int randomOne = Random.Range(1, 2);

			if (othersCount == randomOne)
			{
				Debug.Log(randomOne);
				this.name = "The One";
			}

		}

		isFacingRight = RandomBool ();
		if (this.name == "The Line") {
					
			speed = 2f;
				} else {
						speed = Random.Range (0.5f, 1.5f);
			this.gameObject.GetComponent<Animator> ().speed = speed * 3;
				}


	}

	public void Update()
	{
		if (this.transform.localPosition.x > GameManager.widthOfScreen / 2) {
						this.isFacingRight = false;		
		} else if (this.transform.localPosition.x < -GameManager.widthOfScreen / 2) {
			this.isFacingRight = true;		

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
						spaceDown = true;
			//Debug.Log("Space Down");
				} else {
			spaceDown = false;		
		}

	}

	public bool RandomBool()
	{
		int random = Random.Range (0, 2);
		if (random == 0) {
			
			return false;	
		} else {
			return true;		
		}


	}

	void OnMouseDown ()
	{
		Debug.Log("This is not the one");
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (this.name == "The Line") {
		
			if (other.name == "The One")
			{
				//Debug.Log("This is the one");

				if (spaceDown)
				{
					Debug.Log("Catch ya!");
					GameManager.triedTimes++;
				}
			}

			else if (other.name == "Other" || other.name == "Other(Clone)")
			{

				if (spaceDown)
				{
					Debug.Log("Wrong person");
					Destroy(other.gameObject);
					GameManager.triedTimes++;
				}
			}
		}

	}
}
