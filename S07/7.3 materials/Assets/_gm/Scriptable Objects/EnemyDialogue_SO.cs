using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="EnemyDialogue_SO", menuName="ScriptableObjects/EnemyDialogue_SO")]
public class EnemyDialogue_SO : ScriptableObject
{
    public List<string> _replicas = new List<string>();
    public List<AudioClip> _replicaSoudns = new List<AudioClip>();
}
