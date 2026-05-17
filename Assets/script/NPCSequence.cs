using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NPCSequence : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform waypointKamarMandi;
    public Transform waypointRuangMakan;

    void Start()
    {
        StartCoroutine(RunMechanism());
    }

    IEnumerator RunMechanism()
    {
        Debug.Log("Aksi: Bangun Tidur");
        yield return new WaitForSeconds(3f);

        Debug.Log("Navigasi: Menuju Kamar Mandi");
        agent.SetDestination(waypointKamarMandi.position);
        yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

        Debug.Log("Aksi: Cuci Muka");
        yield return new WaitForSeconds(2f);

        Debug.Log("Navigasi: Menuju Ruang Makan");
        agent.SetDestination(waypointRuangMakan.position);
        yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

        Debug.Log("Aksi: Makan");
    }
}