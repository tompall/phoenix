using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NPC:MonoBehaviour {

    //how many times they met with whom
    public Dictionary<AI_NPC,int> KnownNPCs;
    public int ID;
    public List<string> Vocabulary;
    public string[] MostFrequentWords;

    public float rangeOfVision = 10f;
    public float rangeOfHearing = 10f;

    public int loud;


    //decision-map like dictionary of possible actions --> will do/dont(true,false) + mood --> needs work
    public Dictionary<Relationships,bool> relationsMap;
    public Dictionary<eMood, bool> moodMap;
    public Dictionary<eHealth, bool> healthMap;

    public enum eMood { sad, feelingless, allright, good, happy };

    public enum eHealth { dying, sick, ok, well, healthy };

    public enum eSocial { suicide, antisocial, loner, friendly, adhd};

    public enum ePolitical { nazi, altright, liberal, central, apolitical, anarchist, socialist};

    public eMood Mood;
    public eHealth Health;
    public eSocial Social;
    public ePolitical Political;

    public GameObject rootObject;

    public struct Relationships
    {   //derivative values based on relationship data
        public int numFriends;
        public int numPartners;
        public int numEnemies;
    }

    public AI_NPC(){

    }

    public void Initialize(){
        this.Mood = eMood.allright;
        this.Health = eHealth.ok;
        this.Social = eSocial.loner;
        this.Political = ePolitical.central;
    }

    public void RandomDecisions(){

        //algorithm that drives this NPC based on multiple derivatives, like:
            ///if health is sick && mood is happy && numFriends is low
            ///go do something physical with other npc
            ///or
            ///if health is good && mood is sad && vocabulary is few
            ///go chat with multiple partners
            ///etc
    }

    public void UpdateRelationshipStatus(AI_NPC otherNPC){
        
        otherNPC.UpdateRelationshipStatus(this);

        if (KnownNPCs.ContainsKey(otherNPC)){
            KnownNPCs[otherNPC]++;
        }

        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AI_NPC>() != null){
            other.GetComponent<AI_NPC>().UpdateRelationshipStatus(this);
        }
    }

}
