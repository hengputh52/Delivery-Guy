using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public TextMeshProUGUI distanceText;

    void Update()
    {
        if (player == null || target == null) return;

        float distance = Vector3.Distance(player.position, target.position);
        distanceText.text = "Distance: " + Mathf.Round(distance) + " m";
    }
}
