using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RemotePlayerInterpolation : MonoBehaviour
{
    public float positionLerpSpeed = 5f;
    public float rotationLerpSpeed = 5f;

    private Vector3 networkPosition;
    private Quaternion networkRotation;
    private PhotonView photonView;
    private void Update()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            return;
        }

        // Smooth interpolation for remote players
        transform.position = Vector3.Lerp(transform.position, networkPosition, Time.deltaTime * positionLerpSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, networkRotation, Time.deltaTime * rotationLerpSpeed);
    }

    [PunRPC]
    public void UpdatePlayerState(Vector3 position, Quaternion rotation)
    {
        networkPosition = position;
        networkRotation = rotation;
    }
}
