using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
   public float[] position;
   public StatsData stats;

   public PlayerData(GameObject player)
   {
      position = new float[3];
      stats = new StatsData();


      if(player != null && stats != null)
      {
         Debug.Log("PlayerData: Przypisano obecną pozycję");

         position[0] = player.transform.position.x;
         position[1] = player.transform.position.y;
         position[2] = player.transform.position.z;
      }
      else if(player == null || stats == null)
         Debug.Log("PlayerData: Nie przypisano obecnej pozycji");

       
   }
}
