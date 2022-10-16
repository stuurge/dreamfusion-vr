using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Teleport : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider teleProvider;
    private InputAction thumb;
    private bool isActive;
    
    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;    
        
        InputAction teleActivate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        teleActivate.Enable();
        teleActivate.performed += OnTeleportActivate;

        InputAction teleCancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        teleCancel.Enable();
        teleCancel.performed += OnTeleportCancel;

        thumb = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        thumb.Enable();

        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) {
            return;
        }
        if (thumb.triggered) {
            return;
        }
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit)){
            rayInteractor.enabled = false;
            isActive = false;
            return;
        }

        Vector3 finalDes = new Vector3(hit.point.x, 1, hit.point.z);
        TeleportRequest request = new TeleportRequest() {
            //destinationPosition = hit.point,
            destinationPosition = finalDes,
        };

        teleProvider.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        isActive = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context){
        rayInteractor.enabled = true;
        isActive = true;
    }

    private void OnTeleportCancel(InputAction.CallbackContext context){
        rayInteractor.enabled = false;
        isActive = false;
    }
}
