using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {
			room_0, kitchen_0, bathroom_0, living_room_0, bathroom_1, room_1, living_room_1, kitchen_1, kitchen_2,
			room_2, bathroom_2, living_room_2, leave, car, bike, on_time, late
			};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.room_0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (myState);
		if 		(myState == States.room_0) 			{room_0 ();}
		else if (myState == States.kitchen_0) 		{kitchen_0();}
		else if (myState == States.living_room_0) 	{living_room_0();}
		else if (myState == States.bathroom_0) 		{bathroom_0();}
		else if (myState == States.bathroom_1) 		{bathroom_1();}
		else if (myState == States.room_1) 			{room_1();}
		else if (myState == States.living_room_1) 	{living_room_1();}
		else if (myState == States.kitchen_1) 		{kitchen_1();}
		else if (myState == States.kitchen_2) 		{kitchen_2();}
		else if (myState == States.room_2) 			{room_2();}
		else if (myState == States.bathroom_2) 		{bathroom_2();}
		else if (myState == States.living_room_2) 	{living_room_2();}
		else if (myState == States.car) 			{car();}
		else if (myState == States.bike) 			{bike();}
		else if (myState == States.on_time) 		{on_time();}
		else if (myState == States.late) 			{late();}
	}

	#region State handler methods
	void room_0 () {
		text.text = "Harry goes to work every morning, before going to work, Harry likes to do a few things. " +
					"Help Harry to get ready and get to work in time so he does not get yelled by his boss!\n\n" +
					"Harry just woke up in his room and wants to get ready. From his room he can access: " +
					"the living room, the Kitchen or the Bathroom.\n\n" +
					"press L to go to the Living Room, press K to go to the Kitchen and B to go to the Bathroom.";
		if (Input.GetKeyDown(KeyCode.K)) 					{myState = States.kitchen_0;} 
		else if (Input.GetKeyDown(KeyCode.L)) 				{myState = States.living_room_0;}
		else if (Input.GetKeyDown(KeyCode.B)) 				{myState = States.bathroom_0;}
	}

	void kitchen_0 () {
		text.text = "Harry goes to the kitchen but he is too sleepy to make anything to eat. " +
					"maybe a little bit of freshing up could help him, he thinks that its better to go back\n\n" +
					"press R to return to the room.";
		if (Input.GetKeyDown(KeyCode.R)) 					{myState = States.room_0;}
	}

	void living_room_0 () {
		text.text = "Harry goes to the living room but he is so sleepy that he trips and falls in the sofa. " +
					"no way he is ready to leave to work in this state!. He thinks that its better to go back\n\n" +
					"press R to return to the room.";
		if (Input.GetKeyDown(KeyCode.R)) 					{myState = States.room_0;}
	}

	void bathroom_0 () {
		text.text = "Harry goes to the bathroom and finds the shower. I could use some freshing up, he says.\n\n" +
					"press S to take a shower or press R to return to the room.";
		if (Input.GetKeyDown(KeyCode.S)) 					{myState = States.bathroom_1;}
		else if (Input.GetKeyDown(KeyCode.R)) 				{myState = States.room_0;}
	}

	void bathroom_1 () {
		text.text = "Harry felt great after the shower, he washed his teath and dressed up. " +
					"now all he needed was to get out of the bathroom and get some breakfast.\n\n" +
					"press L to go to the Living Room, press K to go to the Kitchen or R to go to the room.";
		if (Input.GetKeyDown(KeyCode.K)) 					{myState = States.kitchen_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 				{myState = States.living_room_1;}
		else if (Input.GetKeyDown(KeyCode.R)) 				{myState = States.room_1;}

	}

	void room_1 () {
		text.text = "Harry goes back to the room and looks at his warm and comfty bed.\n" +
					"He thought to go back and snuggle but his boss wouldnt be very happy with the idea " +
					"better go back he said\n\n" +
					"press R to return to the room.";
		if (Input.GetKeyDown(KeyCode.R)) 					{myState = States.bathroom_1;}
	}

	void living_room_1 () {
		text.text = "Harry goes to the living room but he is too hungry to do anything " +
					"better to get some breakfast because its going to be a long day " +
					"better go back he thought\n\n" +
					"press R to return back.";
		if (Input.GetKeyDown(KeyCode.R)) 					{myState = States.bathroom_1;}
	}

	void kitchen_1 () {
		text.text = "Harry goes to the kitchen and finds his favourite cereal ready to prepare!.\n\n" +
					"press E so Harry can eat his breakfast or press R to return.";
		if (Input.GetKeyDown(KeyCode.E)) 					{myState = States.kitchen_2;}
		else if (Input.GetKeyDown(KeyCode.R)) 				{myState = States.bathroom_1;}
	}

	void kitchen_2 () {
		text.text = "Harry finished his breakfast and was ready to start the day.\n" +
					"Better get out quick so I dont arrive late he thought\n\n" +
					"press R to go to the room, L to go to the living room or B to go to the Bathroom";
		if (Input.GetKeyDown(KeyCode.B)) 					{myState = States.bathroom_2;}
		else if (Input.GetKeyDown(KeyCode.L)) 				{myState = States.living_room_2;}
		else if (Input.GetKeyDown(KeyCode.R)) 				{myState = States.room_2;}
	}

	void room_2 () {
		text.text = "Harry whent back to the room in case he forgot anything, " +
					"since all was good, he thought there was no point staying any longer\n\n" +
					"press R to return to the room.";
		if (Input.GetKeyDown(KeyCode.R)) 					{myState = States.kitchen_2;}
	}

	void bathroom_2 () {
		text.text = "Harry goes to the bathroom again to washes his teeth, " +
					"once he finished he decided to leave since he felt ready\n\n" +
					"press R to return.";
		if (Input.GetKeyDown(KeyCode.R)) 					{myState = States.kitchen_2;}
	}

	void living_room_2 () {
		text.text = "In the living room harry picks his suitcase and keyes ready to leave, " +
					"but he is not sure if to leave by bike or car.\n\n" +
					"press B to get the bike or C to take the car.";
		if (Input.GetKeyDown(KeyCode.B)) 					{myState = States.bike;}
		else if (Input.GetKeyDown(KeyCode.C)) 				{myState = States.car;}
	}

	void bike () {
		text.text = "Harry gets on the bike ready to leave, he looks back home thinking he did not forget anything\n\n" +
					"press R to return or L to leave.";
		if (Input.GetKeyDown(KeyCode.R)) 					{myState = States.living_room_2;}
		else if (Input.GetKeyDown(KeyCode.L)) 				{myState = States.late;}
	}

	void car () {
		text.text = "Harry gets in the bike ready to leave, he looks back home thinking he did not forget anything.\n\n" +
					"press R to return or L to leave.";
		if (Input.GetKeyDown(KeyCode.R)) 					{myState = States.living_room_2;}
		else if (Input.GetKeyDown(KeyCode.L)) 				{myState = States.on_time;}
	}

	void on_time () {
		text.text = "Harry arrived to work on time besides the traffic Jam, a lot of people don't know this " +
					"but he used to be an excellent rally driver. He had an excellent day at work and he got hammerd with his work colleagues.\n" +
					"He then called an Uber and went back home.\n\n" + 
					"Press S to start the game again.";
		if (Input.GetKeyDown(KeyCode.S)) 					{myState = States.room_0;}
	}

	void late () {
		text.text = "Harry was happy that he avoided the traffic jam but suddently his chain came out, " +
					"he managed to fix it but arrived late to work, he got a warning from is manager and had to stay late.\n" +
					"Harry remembered the good old days of being a rally driver and though he should have taken the car instead.\n\n" + 
					"Press S to start the game again.";	
		if (Input.GetKeyDown(KeyCode.S)) 					{myState = States.room_0;}
	}
	#endregion
}
