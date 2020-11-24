// GENERATED AUTOMATICALLY FROM 'Assets/Drones/Input/DroneInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DroneInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DroneInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DroneInput"",
    ""maps"": [
        {
            ""name"": ""Drone"",
            ""id"": ""c3d56a9b-d009-405b-8ba6-aae777ee394c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""611b8559-bf1f-4d27-9727-65c1ebbef0fc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Value"",
                    ""id"": ""7c03b406-3911-4ca3-a646-1145c1711fa9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""7a3902f0-2cf5-4613-83e5-c70ee72e9724"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yaw"",
                    ""type"": ""Value"",
                    ""id"": ""8f67ac9d-ff57-42cb-baf4-ed4cbfe92d80"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""00e33615-9131-4cc0-a4e3-6fcf0de28e83"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""d6ffd9c5-592d-40ca-8e6e-006e4e149009"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e8f48e6b-024a-4220-ba2c-7b10dd5f52f7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d87f9868-74b4-4ec5-8f85-ba80cb9ddb4b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bace7599-47ce-4719-abb3-65c5eb424795"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""af60ca63-ea33-4d01-8599-35fe7ac342e4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""98978f14-28c2-4b20-a679-88c6783219a6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""88fa7275-df82-4c63-b4f9-315b189b2202"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4adf8093-f060-4c60-a7a1-b9aaff1f92ec"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""5c208afd-86cf-4e96-a796-459863cd8a5c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8a801410-92f8-4a2d-985d-a0c1d066e96c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9fb9af72-4632-4429-955a-716ff7476adf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1ce001bc-20ea-4b72-9eb7-f27c45a4c9b2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b64c259c-1554-43fb-a19d-b413c365a8df"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""295616f7-ebd0-4a44-95fd-f42b26fbcc5a"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""4ab8b9f0-cd92-4a5d-a727-44437a53e72c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""36aa4344-c52b-4457-b65a-06a643a181d5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""603911db-4602-4abd-ac77-228b6efa3d0f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""730c31c9-d516-44dd-af58-a68d8258f250"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6f2c6950-dc35-437c-a400-b0513e289171"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a4032dc8-39af-4a7b-b78f-b1957a7e4a36"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a0cb22c3-0a5e-4635-851f-bd16d1e50641"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Yaw"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e2f0d609-b0eb-403d-a5dc-95b5151a24b8"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bd7e3b72-af8c-49c4-92b9-a2a186697b1c"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""cd67af4c-31e4-42ab-ad3f-7c0ac3a40b73"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Yaw"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f52c63b7-d6d8-4a44-a59b-bbcc82388dd3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""61fb5fb0-f739-4d73-9545-47736997722a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""14f05918-1bcf-4191-8b85-ad2831b14c78"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Yaw"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0973edef-3fce-4ade-a764-7e8915cb28cb"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4da9ea6f-01ca-4c50-9637-327de6c290f6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Drone
        m_Drone = asset.FindActionMap("Drone", throwIfNotFound: true);
        m_Drone_Move = m_Drone.FindAction("Move", throwIfNotFound: true);
        m_Drone_Throttle = m_Drone.FindAction("Throttle", throwIfNotFound: true);
        m_Drone_Rotate = m_Drone.FindAction("Rotate", throwIfNotFound: true);
        m_Drone_Yaw = m_Drone.FindAction("Yaw", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Drone
    private readonly InputActionMap m_Drone;
    private IDroneActions m_DroneActionsCallbackInterface;
    private readonly InputAction m_Drone_Move;
    private readonly InputAction m_Drone_Throttle;
    private readonly InputAction m_Drone_Rotate;
    private readonly InputAction m_Drone_Yaw;
    public struct DroneActions
    {
        private @DroneInput m_Wrapper;
        public DroneActions(@DroneInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Drone_Move;
        public InputAction @Throttle => m_Wrapper.m_Drone_Throttle;
        public InputAction @Rotate => m_Wrapper.m_Drone_Rotate;
        public InputAction @Yaw => m_Wrapper.m_Drone_Yaw;
        public InputActionMap Get() { return m_Wrapper.m_Drone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DroneActions set) { return set.Get(); }
        public void SetCallbacks(IDroneActions instance)
        {
            if (m_Wrapper.m_DroneActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnMove;
                @Throttle.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnThrottle;
                @Rotate.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnRotate;
                @Yaw.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnYaw;
                @Yaw.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnYaw;
                @Yaw.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnYaw;
            }
            m_Wrapper.m_DroneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Yaw.started += instance.OnYaw;
                @Yaw.performed += instance.OnYaw;
                @Yaw.canceled += instance.OnYaw;
            }
        }
    }
    public DroneActions @Drone => new DroneActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IDroneActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnThrottle(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnYaw(InputAction.CallbackContext context);
    }
}
