//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
namespace States
{
	public class LockingState:InteractionState
	{
		private Renderer rend;/**The renderer so we can change the color of the frame lights*/
		
		public LockingState (GameObject _actee, GameObject _actor):base(_actee, _actor){ }


		/**
		 * Changes the emission color of the actee to red, then returns a new idleState
		 * @return InteractionState - the idle state so the door is locked
		 * */
		public override InteractionState Behave ()
		{
			this.rend = this.actee.GetComponentInChildren<Renderer>();
			
			//if we have the renderer, change the frame light color
			if(this.rend != null)
			{
				rend.material.EnableKeyword ("_EMISSION");
				rend.material.SetColor("_EmissionColor", Color.red);
			}

			return new IdleState(this.actee, this.actor);
		}
	}
}
