//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

/**
 * Filename: QuestionSelectState
 * Author: Jakob Wilson
 * Created: 5/22/2015
 * Revision: 1
 * Rev. Date: 
 * Rev. Author: 
 * */

using System;
using UnityEngine;
using Database;

namespace States
{
	public class QuestionSelectState:InteractionState
	{
		/**
		 * Calls base constructor
		 * */
		public QuestionSelectState (GameObject _actee, GameObject _actor):base(_actee, _actor){}

		/**
		 * queries the database based on constraints and returns the appropriate state for the question selected
		 * @return InteractionState - the correct question state or an idle state on error
		 * */
		public override InteractionState Behave ()
		{
			QuestionQuery query;				/**<The query we want to use*/
			QuestionRestraints rest;			/**<The question restraints script(if available)*/
			QuestionPool questions;				/**<The question pool*/
			Question question;					/**<The question we swlwct from our pool*/
			System.Random rnd;					/**<A random number generator for selecting the question*/
		
			rnd = new System.Random();
			rest = this.actee.GetComponent<QuestionRestraints> ();


			if (rest != null)											//if actee has a restraint script, then use that to create restraints
				query = rest.QueryObject;
			else 														//else use no restraints
				query = new QuestionQuery ();


			questions = DatabaseConnector.Instance.GetQuestions(query);	//use restaints to query the database for a question pool


			if(questions.Count <= 0)									//if there are no questions, then there was probably an error so just leave the door as it is
				return new IdleState(this.actee, this.actor);
			else  														//else select a random question from that pool				
				question = questions[rnd.Next(0,questions.Count)];



			if (question.Type == "MULTIPLE_CHOICE") {
				Debug.Log("Mulitple choice question: " + question.QuestionString);
				//------create and return multiple choice state--------
			}

			if (question.Type == "TRUE_FALSE") {
				Debug.Log("True/false question: " + question.QuestionString);
				//--------create and return true false state--------
			}

			if (question.Type == "SHORT_ANSWER") {
				Debug.Log("Short answer question: " + question.QuestionString);
				//--------create and return short answer state--------
			}

			//failsafe
			return new OpeningState(this.actee, this.actor);
		}
	}
}

